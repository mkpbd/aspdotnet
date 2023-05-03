using Microsoft.EntityFrameworkCore;
using MVCProjectBootsrping.Models;

namespace MVCProjectBootsrping.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}
