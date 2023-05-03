using Microsoft.EntityFrameworkCore;
using MVCProjectBootsrping.Data;
using MVCProjectBootsrping.Data.Migrations;
using MVCProjectBootsrping.Models;
using System.Linq;
using System.Linq.Expressions;

namespace MVCProjectBootsrping.Repository
{
    public class EmployeeReposiory : IEmployeeReposiory
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<Employee> _dbSet;
        protected int CommandTimeout { get; set; }


        public EmployeeReposiory(ApplicationDbContext dbContext)
        {
            CommandTimeout = 300;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Employee>();


        }


        public void Add(Employee entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(Employee entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IList<Employee> Get(Expression<Func<Employee, bool>> filter, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public (IList<Employee> data, int total, int totalDisplay) Get(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> Get(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null, string includeProperties = "", bool isTrackingOff = false)
        {

            IQueryable<Employee> query = _dbSet;

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

        public IList<Employee> GetAll()
        {
            return _dbSet.ToList();
        }

        public Employee GetById(int id)
        {
            return _dbSet.Find(id); ;
        }

        public int GetCount(Expression<Func<Employee, bool>> filter = null)
        {
            IQueryable<Employee> query = _dbSet;
            var count = 0;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            count = query.Count();
            return count;
        }



        public void Remove(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Remove(Employee entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Remove(Expression<Func<Employee, bool>> filter)
        {
            _dbSet.RemoveRange(_dbSet.Where(filter));
        }
    }
}
