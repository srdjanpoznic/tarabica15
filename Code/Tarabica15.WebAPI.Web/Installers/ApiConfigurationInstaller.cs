using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tarabica15.WebAPI.Contracts.Configuration;
using Tarabica15.WebAPI.Web.Common;

namespace Tarabica15.WebAPI.Web.Installers
{
    public class ApiConfigurationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IApplicationConfiguration>()
                .ImplementedBy<ApplicationConfiguration>()
                .LifeStyle.Singleton);
        }
    }
}