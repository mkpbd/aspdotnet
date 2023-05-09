using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application
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
           
        }
    }
}
