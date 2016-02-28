using System.Data.Entity;
using System.Linq;
using DB_WorkEntity.Domain;
using DB_WorkEntity.Entity.Domain;

namespace DB_WorkEntity.Entity.Repository
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll(); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext db;
        
        protected DbSet<T> DbSet;

        public GenericRepository(DbContext dbContext)
        {
            db = dbContext;
            DbSet = db.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Create(T item)
        {
            DbSet.Add(item);
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T item = DbSet.Find(id);
            if (item != null)
                DbSet.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }

    public class Tov_allRepository : GenericRepository<Tov_all>
    {
     //   private Context db;

        public Tov_allRepository()
            : base(new TestContext())
    {
    }

        //public IQueryable<Tov_all> GetAll()
        //{
        //    return db.Tov_all;
        //}

        //public Tov_all Get(int id)
        //{
        //    return db.Tov_all.Find(id);
        //}

        //public void Create(Tov_all book)
        //{
        //    db.Tov_all.Add(book);
        //}

        //public void Update(Tov_all book)
        //{
        //    db.Entry(book).State = EntityState.Modified;
        //}

        //public void Delete(int id)
        //{
        //    Tov_all book = db.Tov_all.Find(id);
        //    if (book != null)
        //        db.Tov_all.Remove(book);
        //}

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
    public class FuelRepository : GenericRepository<Tov_all>
    {
        //   private Context db;

        public FuelRepository()
            : base(new TestContext())
        {
            
        }        
    }
}
