using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tarabica15.WebAPI.Common.Logging;

namespace Tarabica15.WebAPI.Infrastructure.Installers
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILogger>()
                .ImplementedBy<Log4netLogger>().LifestyleSingleton());
        }
    }
}