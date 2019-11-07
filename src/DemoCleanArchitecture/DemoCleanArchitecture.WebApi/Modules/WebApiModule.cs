using Autofac;

namespace DemoCleanArchitecture.WebApi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .InstancePerLifetimeScope();
        }
    }
}
