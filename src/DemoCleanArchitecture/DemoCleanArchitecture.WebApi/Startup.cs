using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using DemoCleanArchitecture.WebApi.DependenceInjection;
using DemoCleanArchitecture.WebApi.Pipeline;
using DemoCleanArchitecture.WebApi.Swagger;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;

[assembly: ApiConventionType(typeof(ApiConventions))]
namespace DemoCleanArchitecture.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            services.AddJwtToken();
            services.Cors();
            services.Swagger();
            services.AddLocalization();
            services.AddProblemDetails();
            services.AddFilters();

            builder.AddAutofacRegistration();
            builder.Populate(services);

            var container = builder.Build();            

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var serviceProvider = app.ApplicationServices;
            var resouces = serviceProvider.GetService<IStringLocalizer<Resources.ReturnMessages>>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCors();            
            app.AddLocalization();
            app.UseProblemDetails();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(env, resouces).Invoke
            });

            app.UseAuthentication();
            app.Swagger();
            app.AddOptions();            
            //app.UseMvc();
        }
    }
}
