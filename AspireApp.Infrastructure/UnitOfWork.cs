﻿using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using AspireApp.Infrastructure.Data;
using AspireApp.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AspireAppDbContext _context;
        private Hashtable _repositories;  // Hashtable to cache repositories


        public UnitOfWork(AspireAppDbContext context)
        {
            _context = context;
        }
        // Get a repository for a specific entity type T
        public IGenericBase<T> Repository<T>() where T : Entity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(IRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericBase<T>)_repositories[type];
        }

        // Commit all changes to the database
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();

        }
    }
}