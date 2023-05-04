using DDDunitOfWork.Reopsitory;

namespace DDDunitOfWork.UnitOfWroks
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IPersonRepository PersonRepository { get; }

        void Save();
    }
}
