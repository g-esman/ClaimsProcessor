using ClaimsProcessor.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace ClaimsProcessor.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<IValidateClaim, ValidateClaim>();
            return services;
        }
    }
}
