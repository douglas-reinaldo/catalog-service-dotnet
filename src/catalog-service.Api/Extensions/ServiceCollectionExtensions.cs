using catalog_service.Application.Common.Interfaces.Persistence;
using catalog_service.Application.Users.CreateUser;
using catalog_service.Infrastructure.Persistence;
using catalog_service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace catalog_service.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 26))
                )
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CreateUserHandler>();

            return services;
        }
    }
}
