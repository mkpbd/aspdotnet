using DDDunitOfWork.Data;
using DDDunitOfWork.Models;

namespace DDDunitOfWork.Reopsitory
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public void Add(Employee  employee)
        {
            _context.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
           return _context.Employees.Where(x => x.Id ==  id).FirstOrDefault();
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}
