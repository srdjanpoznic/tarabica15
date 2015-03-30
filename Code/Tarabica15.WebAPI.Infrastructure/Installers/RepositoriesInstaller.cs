using System.Data.Entity;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tarabica15.WebAPI.Data.Models;

namespace Tarabica15.WebAPI.Infrastructure.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Example of registering Data repository
            //var connectionString = ConnectionStrings.ConnectionString;
            //Dictionary<string, object> arguments = new Dictionary<string, object>
            //{
            //    {"connectionString", connectionString},
            //    {"providerName", "System.Data.SqlClient"}
            //};

            //container.Register(
            //    Component.For<IDataRepository>()
            //    .ImplementedBy<DataRepository>()
            //    .DependsOn(arguments)
            //    .LifestylePerWebRequest());

            container.Register(
                Component.For<Tarabica15Context>()
                .ImplementedBy<Tarabica15Context>()
                .LifestylePerWebRequest());
        }
    }
}