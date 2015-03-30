using System;
using Castle.Windsor;

namespace Tarabica15.WebAPI.Infrastructure
{
    public class ContainerApplication : IContainerAccessor, IDisposable
    {
        private readonly IWindsorContainer _container;

        public ContainerApplication()
        {
            _container = new WindsorContainer();
        }

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public T Resolve<T>(string name)
        {
            return _container.Resolve<T>(name);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
