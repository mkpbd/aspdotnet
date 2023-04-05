using AdoNetBasic.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoNetBasic
{
    public class MyDataClassesDataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventorie> ProductInventories { get; set; }

    }
}
