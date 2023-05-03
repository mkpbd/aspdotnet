using DDDGroupStudy.Web.Models;

namespace DDDGroupStudy.Web.Repository
{
    public interface IEmployeeRepository 
    {
        public void Add(Employee employee);

        public Employee GetById(int id);
        public void Remove(Employee employee);
        public void Remove(int id);
        public List<Employee> GetAll();
    }
}
