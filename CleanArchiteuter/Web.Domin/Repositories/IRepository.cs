using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Domin.Entities;

namespace Web.Domin.Repositories
{
    public interface IRepository<TEntity, TKey>  where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
        IList<TEntity> GetAll();
        TEntity GetById(TKey id);

    }
}
