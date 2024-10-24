using AspireApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces.Common
{
    public interface IGenericBase<T> : IGenericAdd<T>, IGenericGet<T>, IGenericUpdate<T>, IGenericDelete<T>
        where T : Entity
    {
        Task<bool> Exist(T entity);
    }
}
