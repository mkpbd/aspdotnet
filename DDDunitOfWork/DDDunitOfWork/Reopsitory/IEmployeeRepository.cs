using DDDunitOfWork.Models;

namespace DDDunitOfWork.Reopsitory
{
    public interface IEmployeeRepository
    {
        public void Add(Employee employee);
        public Employee GetById(int id);
        public List<Employee> GetAll();
        public void Remove(Employee employee);

    }
}
