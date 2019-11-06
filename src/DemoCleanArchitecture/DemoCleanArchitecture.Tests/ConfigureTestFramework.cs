using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;
using Autofac;
using DemoCleanArchitecture.Infrastructure.Modules;
using DemoCleanArchitecture.WebApi;

[assembly: TestCollectionOrderer("DemoCleanArchitecture.Tests.TestCaseOrdering", "DemoCleanArchitecture.Tests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("DemoCleanArchitecture.Tests.ConfigureTestFramework", "DemoCleanArchitecture.Tests")]
namespace DemoCleanArchitecture.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {            
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();
        }
    }
}
