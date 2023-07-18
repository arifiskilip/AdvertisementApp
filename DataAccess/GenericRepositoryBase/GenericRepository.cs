using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.GenericRepositoryBase
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly AdvertisementContext _context;

        public GenericRepository(AdvertisementContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool asNotTracking = false)
        {
            return !asNotTracking ? 
                (filter == null ? await _context.Set<T>().ToListAsync() 
                : await _context.Set<T>().Where(filter).ToListAsync()) 
                : (filter == null ? await _context.Set<T>().AsNoTracking().ToListAsync() 
                : await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
