using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAnri.Controllers.Data;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        DataContext _context { get; }

        public Task<T?> GetSingleOrDefaultAsync(int id);

        public Task<IEnumerable<T?>> GetAllAsync();

        public Task<bool> AddAsync(T entity);

        public Task<bool> UpdateAsync(T entity);
        public IQueryable<T> Query();

        public Task<bool> DeleteAsync(int id);

    }
}
