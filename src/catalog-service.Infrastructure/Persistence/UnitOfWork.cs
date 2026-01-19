using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using catalog_service.Domain.Interfaces;
using catalog_service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace catalog_service.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository? _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository 
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_context); }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
