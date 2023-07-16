using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERVER\\MSSQLSERVER01;Database=myDataBase;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
           // modelBuilder.ApplyConfiguration<CustomerConfiguration>();

        }

    }
}