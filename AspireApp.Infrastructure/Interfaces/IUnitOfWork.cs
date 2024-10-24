using AspireApp.Core.Abstracts;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork<TEntity>: IDisposable where TEntity : EntityBase
    {
        // Generic method to get a repository for a specific entity type
        IRepository<TEntity> Repositories { get;  }
        Task<int> CompleteAsync();
    }
}
