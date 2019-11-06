using Autofac;
using DemoCleanArchitecture.WebApi.UseCases.Customer;

namespace DemoCleanArchitecture.WebApi.DependenceInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)                
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerPresenter>().As<Application.Boundaries.Customer.IOutputPort>()
                .AsSelf()
                .InstancePerLifetimeScope();
            return builder;
        }
    }
}
