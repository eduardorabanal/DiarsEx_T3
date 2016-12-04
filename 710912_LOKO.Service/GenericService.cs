using _710912_LOKO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _710912_LOKO.Service
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        //public GenericService()
        //{
        //    if (_genericRepository == null)
        //    {
        //        _genericRepository = new GenericRepository<TEntity>();
        //    }
        //}

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<TEntity> PerformInclusions(IEnumerable<Expression<Func<TEntity, object>>> includeProperties,
                                                      IQueryable<TEntity> query)
        {
            return _genericRepository.PerformInclusions(includeProperties, query);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _genericRepository.AsQueryable();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericRepository.Find(where, includeProperties);
        }
        public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericRepository.FindQueryable(where, includeProperties);
        }

        public void Add(TEntity entidad)
        {
            _genericRepository.Add(entidad);
        }

        public void Commit()
        {
            _genericRepository.Commit();
        }

        public TEntity GetById(int? id)
        {
            return _genericRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _genericRepository.Remove(id);
        }

        public void Edit(TEntity entity)
        {
            _genericRepository.Edit(entity);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _genericRepository.GetAll(includeProperties);
        }
    }
}
