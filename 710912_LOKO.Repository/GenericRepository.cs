using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context Context;

        public GenericRepository()
        {
            if (Context == null)
            {
                Context = new Context();
            }
        }

        public IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                      IQueryable<TEntity> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }
        public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public void Add(TEntity entidad)
        {
            Context.Set<TEntity>().Add(entidad);
            Context.SaveChanges();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public TEntity GetById(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Remove(int id)
        {
            Context.Set<TEntity>().Remove(GetById(id));
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> SearchByCriteria(Expression<Func<TEntity, bool>> criterio)
        {
            return Context.Set<TEntity>().Where(criterio);
        }

        public void Edit(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query;
            //return Context.Set<TEntity>();
        }
    }
}
