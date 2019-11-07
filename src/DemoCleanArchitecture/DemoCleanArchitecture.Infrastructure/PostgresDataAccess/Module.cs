using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DEMOCLEAN_CONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("PostgresDataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            /*
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => t.Namespace.Contains("PostgresDataAccess") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Context>().InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(connection))
            {
                using (var context = new Context())
                {
                    context.Database.Migrate();
                    //ContextInitializer.Seed(context);
                }
            }
            */
        }
    }
}
