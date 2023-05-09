using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domin.Entities;
using WebApp.Domin.Repositories;

namespace WebApp.Persistence
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

        protected DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        protected int CommandTimeout { get; set; }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            CommandTimeout = 600;
        }

       public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Edit(TEntity entityToUpdate)
        {
           
            if(_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }

            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var count = 0;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            count = query.Count();
            return count;
        }

        public void Remove(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Remove(Expression<Func<TEntity, bool>> filter)
        {
            _dbSet.RemoveRange(_dbSet.Where(filter));
        }
    }
}
