using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEzconet.Domain;

namespace TesteEzconet.Persistence
{
    public class Repository : IRepository
    {
        private readonly TesteEzconetContext dbContext;

        public Repository (TesteEzconetContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public Task AddAsync<T>(T entity) where T : class
        {
            return dbContext.AddAsync(entity).AsTask();
        }

        public Task AddAsync<T>(IEnumerable<T> entities) where T : class
        {
            return dbContext.AddRangeAsync(entities);
        }       

        public void Remove<T>(T entity) where T : class
        {
            dbContext.Remove(entity);
        }

        public void Remove<T>(IEnumerable<T> entities) where T : class
        {
            dbContext.RemoveRange(entities);
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

    }
}
