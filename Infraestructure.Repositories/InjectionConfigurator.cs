using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infraestructure.Repositories
{
    public class InjectionConfigurator
    {
        public static ContainerBuilder Container()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<InfrastructureModule>();
            return containerBuilder;
        }

        public static IServiceProvider Configure(IServiceCollection services)
        {
            var containerBuilder = Container();

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return container.Resolve<IServiceProvider>();
        }
    }
}
