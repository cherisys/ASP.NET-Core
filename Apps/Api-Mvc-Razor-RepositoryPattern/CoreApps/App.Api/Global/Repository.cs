using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Global
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApiDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long Id)
        {
            var TEntity = await _dbSet.SingleOrDefaultAsync(e => e.Id == Id);
            if (TEntity != null)
            {
                _dbSet.Remove(TEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await  _dbSet.ToListAsync();
        }

        public async Task<T> GetById(long Id)
        {
            return await _dbSet.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public async Task Update(T entity)
        {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
        }
    }
}
