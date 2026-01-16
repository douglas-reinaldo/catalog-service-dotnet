using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using catalog_service.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace catalog_service.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
