using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        // Generic method to get a repository for a specific entity type
        IGenericBase<T> Repository<T>() where T : Entity;
        Task<int> CompleteAsync();
    }
}
