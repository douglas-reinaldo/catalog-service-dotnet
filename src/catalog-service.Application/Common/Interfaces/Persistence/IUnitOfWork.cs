using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace catalog_service.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
