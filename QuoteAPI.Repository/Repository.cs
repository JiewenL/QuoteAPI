using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace QuoteAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Put(T item);
        void Post(T item);
        T Delete(int id);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Put(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Post(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public T Delete(int id)
        {
            T item = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(item);
            Context.SaveChanges();
            return item;
        }
    }
}