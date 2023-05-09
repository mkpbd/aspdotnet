﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Persistence;

namespace WebApp.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, x => x.MigrationsAssembly(_migrationAssembly));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



    }
}