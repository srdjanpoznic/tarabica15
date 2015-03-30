using System.Web.Http;
using System.Web.OData;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Tarabica15.WebAPI.Web.Installers
{
    public class ApiControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<ODataController>()
                .LifestylePerWebRequest());
        }
    }
}