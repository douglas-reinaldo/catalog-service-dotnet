using catalog_service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int id);
    }


}
