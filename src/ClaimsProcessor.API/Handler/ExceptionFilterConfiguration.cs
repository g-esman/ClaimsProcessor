namespace ClaimsProcessor.API.Handler
{
    public static class ExceptionFilterConfiguration
    {
        public static IServiceCollection AddExceptionFilterConfiguration(
            this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
            return services;
        }
    }
}
