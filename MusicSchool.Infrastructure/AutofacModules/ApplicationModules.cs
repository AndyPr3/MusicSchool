using Autofac;
using MediatR;
using System.Reflection;

namespace MusicSchool.Infrastructure.AutofacModules
{
    public class ApplicationModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                   .AsImplementedInterfaces();

            var applicationAssembly = Assembly.Load("MusicSchool.Application");
            builder.RegisterAssemblyTypes(applicationAssembly)
                   .AsClosedTypesOf(typeof(IRequestHandler<,>))
                   .InstancePerDependency();
        }
    }
}
