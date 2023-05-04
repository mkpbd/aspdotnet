using DDDunitOfWork.Data;
using DDDunitOfWork.Reopsitory;

namespace DDDunitOfWork.UnitOfWroks
{
    public class UnitOfWork : IUnitOfWork
    {
      
        public readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext application)
        {
            _applicationDbContext = application;

        }
        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_applicationDbContext);
        public IPersonRepository PersonRepository => new PersonRepository(_applicationDbContext);

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
