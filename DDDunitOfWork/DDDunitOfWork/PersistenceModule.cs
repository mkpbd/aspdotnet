using Autofac;
using DDDunitOfWork.Data;
using DDDunitOfWork.Reopsitory;
using DDDunitOfWork.UnitOfWroks;

namespace DDDunitOfWork
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
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
            .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PersonRepository>().As<IPersonRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
