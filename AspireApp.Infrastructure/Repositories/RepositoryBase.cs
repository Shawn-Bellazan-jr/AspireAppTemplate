using AspireApp.Core.Entities;
using AspireApp.Core.Interfaces;
using AspireApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get all entities
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get an entity by ID
        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Add a new entity
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update an existing entity
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete an entity by ID
        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id.ToString());
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Check if an entity exists
        public async Task<bool> Exist(T entity)
        {
            // Example: Check if the entity exists by its ID
            return await _dbSet.AnyAsync(e => e.Equals(entity   ));
        }
    }
}
