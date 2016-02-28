using DB_WorkEntity.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DB_WorkEntity.Entity.Repository
{
    public class GenericUnitOfWork : IDisposable//, IGenericUnitOfWork

    {
        protected DbContext dbContext;

        private bool disposed;

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public GenericUnitOfWork()
            : this(new TestContext())
        {

        }
        public GenericUnitOfWork(DbContext context)
        {
            dbContext = context;
        }

        public IRepository<T> Repository<T>() 
            where T: class
//            where E: class, new()
        {
            if (Repositories.Keys.Contains(typeof (T)))
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(dbContext);

            Repositories.Add(typeof (T), repo);
            return repo;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Exception when Save\n" + e.Message);
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
