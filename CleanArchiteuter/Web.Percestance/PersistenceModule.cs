using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application;
using Web.Application.Features.Traning.Repository;
using Web.Percestance.Features;

namespace Web.Percestance
{
    public class PersistenceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public PersistenceModule(string connectionString, string migrationAssemblyName) {
        
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

        }
    }
}
