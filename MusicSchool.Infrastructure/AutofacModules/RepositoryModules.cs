using Autofac;
using MusicSchool.Infrastructure.Data;
using System.Reflection;

namespace MusicSchool.Infrastructure.AutofacModules
{
    public class RepositoryModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DataBaseContext>()
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
