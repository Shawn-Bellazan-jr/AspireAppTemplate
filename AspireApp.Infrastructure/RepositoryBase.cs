using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly List<T>? _entities = default;
        public async Task Add(T type) => await Task.Run(() => _entities?.Add(type));

        public async Task Delete(T type) => await Task.Run(() => _entities?.Remove(type));

        public async Task<IEnumerable<T>?> Get() => await Task.Run(() => _entities?.ToList() ?? new());

        public async Task<T?> Get(T type) => await Task.Run(() => _entities?.SingleOrDefault(x => x == type));

    }
}
