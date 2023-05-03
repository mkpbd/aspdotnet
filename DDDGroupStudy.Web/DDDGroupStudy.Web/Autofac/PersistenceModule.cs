using Autofac;
using DDDGroupStudy.Web.Data;
using DDDGroupStudy.Web.Repository;

namespace DDDGroupStudy.Web.Autofac
{
    public class PersistenceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public PersistenceModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();


        }


    }
}
