using CrudWithAjaxApplication.Data;
using CrudWithAjaxApplication.GenericInterfaces;

namespace CrudWithAjaxApplication.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICustomerRepository Customer { get; set; }
        public UnitOfWork(   ApplicationDbContext context  )
        {
            _context = context;
            Customer = new CustomerRepository(_context);
        }
        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
