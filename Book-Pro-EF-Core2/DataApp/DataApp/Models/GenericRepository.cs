using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IGenericRepository<T> where T:class
    {
        T Get(long Id);
        IEnumerable<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(long Id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EFDatabaseContext context;
        public GenericRepository(EFDatabaseContext ctx) => context = ctx;
       
        public virtual void Add(T t)
        {
            context.Add<T>(t);
            context.SaveChanges();
        }

        public virtual void Delete(long Id)
        {
            context.Remove<T>(Get(Id));
            context.SaveChanges();
        }

        public virtual T Get(long Id)
        {
            return context.Set<T>().Find(Id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual void Update(T t)
        {
            context.Update<T>(t);
            context.SaveChanges();
        }
    }
}
