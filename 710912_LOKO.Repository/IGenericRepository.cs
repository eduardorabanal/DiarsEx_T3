using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties, IQueryable<TEntity> query);
        IQueryable<TEntity> AsQueryable();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(Int32? id);

        void Add(TEntity entidad);
        void Remove(Int32 id);
        void Commit();
        void Edit(TEntity entity);
    }
}
