using AdoNetBasic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
     public   DbSet<ProductInventorie> ProductInventories { get; set; }

    }
}
