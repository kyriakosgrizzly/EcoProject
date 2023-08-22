using Microsoft.EntityFrameworkCore;
using MVCAnri.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<T?> GetSingleOrDefaultAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetSingleOrDefaultAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entity);
            return true;
        }
        public bool DeleteRange(List<T> entities)
        {

            _context.RemoveRange(entities);

            return true;
        }

        public DataContext GetContext()
        {
            return _context;
        }
        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
