using LazyNews.Core.Contracts;
using LazyNews.Core.Models;
using LazyNews.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyNews.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var t = Find(id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);

        }

        public IQueryable<T> FindHeadlines(string Headline)
        {
            //var hd = dbSet.Where(x => x.Headline == Headline).ToList();
            //if (hd != null)
            //{
            //    return hd;
            //}
            //else
            //{
            //    return null;
            //}

            return dbSet.Where(x => x.Headline == Headline);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}