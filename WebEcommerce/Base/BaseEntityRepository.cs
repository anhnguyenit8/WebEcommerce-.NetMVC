using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Models;

namespace WebEcommerce.Base
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : class,
        IBaseEntity
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities; 

        public BaseEntityRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityId = await _entities.FirstOrDefaultAsync(x=> x.Id==id);
            if(entityId != null)
            {
                _entities.Remove(entityId);
                await SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        => await _entities.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _entities.AsQueryable();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync();
        }

       

        public async Task<T> GetByIdAsync(int id)

        => await _entities.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _entities.AsQueryable();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry =_context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await SaveChanges();
        }
    }
}
