using CrudWithAjaxApplication.Data;
using CrudWithAjaxApplication.GenericInterfaces;
using CrudWithAjaxApplication.Models;

namespace CrudWithAjaxApplication.Repository
{

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
