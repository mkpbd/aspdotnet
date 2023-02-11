using EfCoreWebApps.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebApps.Core.DAL
{
    public class AppDbContext : DbContext
    {


        private const string connectionString =$@"Server=SERVER;Database=MyFirstEfCoreDb;Trusted_Connection=True";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LookUp> LookUps { get; set; }

    }
}
