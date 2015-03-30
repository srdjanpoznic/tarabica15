using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tarabica15.WebAPI.Contracts.Interfaces.Services;

namespace Tarabica15.WebAPI.Infrastructure.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuthenticationService>().ImplementedBy<AuthenticationService.AuthenticationService>().
                LifeStyle.PerWebRequest);
        }
    }
}