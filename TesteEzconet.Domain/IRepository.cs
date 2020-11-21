using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEzconet.Domain
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task AddAsync<T>(IEnumerable<T> entities) where T : class;
        void Remove<T>(T entity) where T : class;
        void Remove<T>(IEnumerable<T> entities) where T : class;
        Task<int> SaveChangesAsync();
    }
}
