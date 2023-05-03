using DDDGroupStudy.Web.Data;
using DDDGroupStudy.Web.Models;

namespace DDDGroupStudy.Web.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void Add(Employee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public List<Employee> GetAll()
        {
           return  _dbContext.Set<Employee>().ToList();

        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
