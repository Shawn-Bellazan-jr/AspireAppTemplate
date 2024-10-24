using AspireApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Core.Interfaces.Common
{
    public interface IGenericGet<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();   // Get all entities of type T
        Task<T?> GetByIdAsync(string id);     // Get a single entity by ID
    }
}
