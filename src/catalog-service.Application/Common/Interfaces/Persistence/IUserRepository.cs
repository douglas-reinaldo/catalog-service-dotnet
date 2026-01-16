using catalog_service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        int AddUser(User user);
    }
}
