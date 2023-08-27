namespace CrudWithAjaxApplication.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        Task<int> CompletedAsync();
    }
}
