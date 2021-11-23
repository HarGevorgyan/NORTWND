using Microsoft.EntityFrameworkCore;
using NORTWND.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NORTWND.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly NORTHWNDContext _context;

        public RepositoryBase(NORTHWNDContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> GetAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IEnumerable<T> GetWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        
    }
}
