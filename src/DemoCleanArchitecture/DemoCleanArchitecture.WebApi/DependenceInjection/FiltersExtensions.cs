using DemoCleanArchitecture.WebApi.Filters;
using DemoCleanArchitecture.WebApi.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCleanArchitecture.WebApi.DependenceInjection
{
    public static class FiltersExtensions
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Conventions.Add(new NotFoundResultApiConvention());
                options.Conventions.Add(new ProblemDetailsResultApiConvention());

            })
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(Resources.SharedResources));
                };
            });//.AddJsonOptions(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            
            return services;
        }
    }
}
