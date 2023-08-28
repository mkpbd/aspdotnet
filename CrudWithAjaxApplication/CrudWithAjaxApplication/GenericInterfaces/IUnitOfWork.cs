namespace CrudWithAjaxApplication.GenericInterfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        Task<int> CompletedAsync();
    }
}
