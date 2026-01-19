using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace catalog_service.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CommitAsync();
    }
}
