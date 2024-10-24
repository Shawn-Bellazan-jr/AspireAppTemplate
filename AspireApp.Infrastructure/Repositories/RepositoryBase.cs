using AspireApp.Core.Abstracts;
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
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
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
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        // Add a new entity
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update an existing entity

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

        public async Task<bool> Exist(T entity)
        {
            // Example: Check if an entity exists by its ID or a unique property
            return await _dbSet.AnyAsync(e => e.Id == entity.Id);  // Assuming `Id` is the unique key
        }


        public async Task UpdateAsync(T type)
        {
            //var exist = await Exist(type);
            //if (!exist) throw new Exception($"Entity with ID {type.Id} not found.");
            _dbSet.Update(type);
            await _context.SaveChangesAsync();
        }
    }
}
