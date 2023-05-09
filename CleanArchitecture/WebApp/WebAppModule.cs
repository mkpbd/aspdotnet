using Autofac;

namespace WebApp
{
    public class WebAppModule : Module
    {

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebAppModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }


        protected override void Load(ContainerBuilder builder)
        {

        }
    }
}
