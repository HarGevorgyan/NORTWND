using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTWND.Core.Abstractions.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Remove(T entity);
        T Add(T entity);
        void Update(T entity);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAll();

        void SaveChanges();
        Task SaveChangesAsync();
        IEnumerable<T> GetWhere(Func<T, bool> predicate);
    }
}
