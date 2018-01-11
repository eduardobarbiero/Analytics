using Applications.Web.Template;
using Autofac;
using AutoMapper;
using System.Reflection;
using Module = Autofac.Module;

namespace Infraestructure.Repositories
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = typeof(ModelToDomainProfile).GetTypeInfo().Assembly;

            builder.RegisterType<UnitOfWorkImpl>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Register(c => new MapperConfiguration(cfg => cfg.AddProfiles(applicationAssembly)).CreateMapper()).AsSelf().SingleInstance();

        }
    }
}
