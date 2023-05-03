using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models.Employee;
using RepositoryPattern.Service;

namespace RepositoryPattern
{
    public class ApplicationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeServices>().As<IEmployeeServices>()
                .InstancePerLifetimeScope();
        }
    }
}
