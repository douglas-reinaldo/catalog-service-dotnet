using catalog_service.Domain.Interfaces;
using catalog_service.Domain.Entities;
using catalog_service.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
