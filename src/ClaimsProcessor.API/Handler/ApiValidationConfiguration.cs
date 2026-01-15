using Microsoft.AspNetCore.Mvc;

namespace ClaimsProcessor.API.Handler
{
    public static class ApiValidationConfiguration
    {
        public static IServiceCollection AddModelValidation(
            this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    if (context.ModelState.ErrorCount > 0 &&
                        context.ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage.Contains("A non-empty request body is required."))))
                    {
                        return new BadRequestObjectResult(
                            new ApiError
                            {
                                Message = "Invalid JSON payload.",
                                Errors = new [] { "A non-empty request body is required." }
                            });
                    }

                    var errors = context.ModelState
                    .Where(ms => ms.Value!.Errors.Count > 0 && IsLeafField(ms.Key))
                    .Select(ms => CleanField(ms.Key))
                    .Distinct()
                    .ToArray();

                    return new BadRequestObjectResult(
                        new ApiError
                        {
                            Message = "Invalid JSON payload.",
                            Errors = errors
                        });
                };
            });
            return services;
        }

        private static bool IsLeafField(string fieldName)
        {
            return fieldName.Contains('.');
        }

        private static string CleanField(string fieldName)
        {
            if (fieldName.Contains('.'))
            {
                return fieldName.Split('.')[1];
            }
            return fieldName;
        }
    }
}
