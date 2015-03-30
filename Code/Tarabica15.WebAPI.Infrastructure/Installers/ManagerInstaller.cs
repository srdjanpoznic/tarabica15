using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Tarabica15.WebAPI.Business.Managers;
using Tarabica15.WebAPI.Contracts.Interfaces;

namespace Tarabica15.WebAPI.Infrastructure.Installers
{
    class ManagerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register Manager classes
            container.Register(Classes.FromAssemblyNamed("Tarabica15.WebAPI.Business")
                            .Where(Component.IsInSameNamespaceAs<BaseManager>()) // alternative: //type => type.Name.EndsWith("Manager")
                            .WithService.DefaultInterfaces()
                            .LifestylePerWebRequest());

            //container.Register(Component.For<IAccountManager>().ImplementedBy<AccountManager>().
            //    LifeStyle.PerWebRequest);

            //container.Register(Component.For<IBookManager>().ImplementedBy<BookManager>().
            //    LifeStyle.PerWebRequest);

            //container.Register(Component.For<ILibraryManager>().ImplementedBy<LibraryManager>().
            //    LifeStyle.PerWebRequest);

            //container.Register(Component.For<IAuthorManager>().ImplementedBy<AuthorManager>().
            //    LifeStyle.PerWebRequest);
        }
    }
}
