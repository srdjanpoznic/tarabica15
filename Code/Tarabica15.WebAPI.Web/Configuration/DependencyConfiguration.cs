using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Tarabica15.WebAPI.Infrastructure;
using Tarabica15.WebAPI.Web.Installers;

namespace Tarabica15.WebAPI.Web.Configuration
{
    public class DependencyConfiguration
    {
        private static ContainerApplication _containerApplication;

        public static void Configure(HttpConfiguration configuration)
        {
            _containerApplication = new ContainerApplicationBuilder()
                .WithDefaultInstallers()
                .WithInstaller(new ApiControllersInstaller())
                .WithInstaller(new ApiConfigurationInstaller());

            var container = _containerApplication.Container;
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;

            RegisterControllerActivator(configuration);
        }

        private static void RegisterControllerActivator(HttpConfiguration configuration)
        {
            if (_containerApplication != null && _containerApplication.Container != null)
            {
                configuration.Services.Replace(typeof(IHttpControllerActivator),
                    new WindsorCompositionRoot(_containerApplication.Container));
            }
        }

        public static void DisposeContainer()
        {
            if (_containerApplication != null)
            {
                _containerApplication.Dispose();
            }
        }

        internal static IWindsorContainer GetContainer()
        {
            return _containerApplication.Container;
        }
    }
}
