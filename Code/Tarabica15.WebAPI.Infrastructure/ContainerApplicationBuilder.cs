using System;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using Castle.MicroKernel.Registration;
using Tarabica15.WebAPI.Infrastructure.Installers;

namespace Tarabica15.WebAPI.Infrastructure
{
    public class ContainerApplicationBuilder
    {
        private readonly ContainerApplication _container;

        public ContainerApplicationBuilder()
        {
            _container = new ContainerApplication();
        }

        public ContainerApplicationBuilder WithFacilities<T>() where T : IFacility, new()
        {
            _container.Container.AddFacility<T>();
            return this;
        }

        public ContainerApplicationBuilder WithFacilities<T>(Action<T> onCreateAction) where T : IFacility, new()
        {
            _container.Container.AddFacility(onCreateAction);
            return this;
        }

        public ContainerApplicationBuilder WithInstaller(IWindsorInstaller installer)
        {
            _container.Container.Install(installer);
            return this;
        }

        public ContainerApplicationBuilder WithDefaultInstallers()
        {
            return WithInstaller(new CommonInstaller())
                .WithInstaller(new ManagerInstaller())
                .WithInstaller(new ServicesInstaller())
                .WithInstaller(new RepositoriesInstaller());
        }

        public ContainerApplicationBuilder WithContributor(IContributeComponentModelConstruction contributor)
        {
            _container.Container.Kernel.ComponentModelBuilder.AddContributor(contributor);
            return this;
        }

        public static implicit operator ContainerApplication(ContainerApplicationBuilder builder)
        {
            return builder.Build();
        }

        public ContainerApplication Build()
        {
            return _container;
        }
    }
}