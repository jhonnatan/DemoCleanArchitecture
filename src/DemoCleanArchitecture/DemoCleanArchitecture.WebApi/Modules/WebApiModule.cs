using Autofac;
using DemoCleanArchitecture.WebApi.UseCases.Customer;
using DemoCleanArchitecture.WebApi.UseCases.Bank;

namespace DemoCleanArchitecture.WebApi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CustomerPresenter>().As<Application.Boundaries.Customer.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<BankPresenter>().As<Application.Boundaries.Bank.IOutputPort>().AsSelf().InstancePerLifetimeScope();

        }
    }
}
