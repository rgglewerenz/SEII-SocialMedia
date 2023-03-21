using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterop
{
    public class GenericRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        internal MainContext context;

        public GenericRepository(MainContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", bool proxyDefault = true) {
            if (!proxyDefault)
                context.Configuration.ProxyCreationEnabled = true;

            IQueryable<T> query = dbSet;

            if (filter != null) {
                query = query.AsNoTracking().Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                query = includeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            }
            return orderBy != null ? orderBy(query).ToList() : query.ToList();

        }
        public IEnumerable<T> GetAttachedList()
        {
            return dbSet.Local.ToList();
        }
        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public void BulkInsert(List<T> entityList)
        {
            dbSet.AddRange(entityList);
        }
        public IQueryable<T> GetQuery(bool proxyDefault = true)
        {
            if (!proxyDefault)
                context.Configuration.ProxyCreationEnabled = true;

            return dbSet.AsNoTracking();
        }

    }
}
