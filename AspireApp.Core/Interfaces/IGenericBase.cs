using AspireApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces
{
    public interface IGenericBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>?> Get();
        Task<T?> Get(T type);
        Task Add(T type);
        Task Delete(T type);
    }
}
