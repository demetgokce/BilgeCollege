using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.Repository
{
    public class DbRepository<TEntity> : IDbRepository<TEntity>
        where TEntity : class, new()
    {
        BilgeDbContext dbContext;
        private DbSet<TEntity> table = null;
        public DbRepository()
        {
            dbContext = new BilgeDbContext();
        }

        public TEntity GetById(int id)
        {

            return dbContext.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            // TEntity entityEntry = dbContext.Entry<TEntity>(entity);


            dbContext.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {

            var query = dbContext.Set<TEntity>().Where(filter);
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));




        }
    }
}
