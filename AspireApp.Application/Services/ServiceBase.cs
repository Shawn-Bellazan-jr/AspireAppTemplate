using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Application.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository;
        protected ServiceBase(IRepositoryBase<T> repository) => _repository = repository;
        public Task Add(T type) => _repository.Add(type);
        public Task Delete(T type) => _repository.Delete(type);
        public Task<IEnumerable<T>?> Get() => _repository.Get();
        public Task<T?> Get(T type) => _repository.Get(type);
    }
}
