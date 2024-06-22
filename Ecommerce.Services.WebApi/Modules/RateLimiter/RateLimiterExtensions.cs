using Microsoft.AspNetCore.RateLimiting;

namespace Ecommerce.Services.WebApi.Modules.RateLimiter
{
    public static class RateLimiterExtensions
    {
        public static IServiceCollection AddRatelimiting(this IServiceCollection services, IConfiguration configuration)
        {
            var fixedWindowsPolicy = "fixedWindow";
            services.AddRateLimiter(configureOptions =>
            {
                configureOptions.AddFixedWindowLimiter(policyName: fixedWindowsPolicy, fixedWindow =>
                {
                    //Numero Max de solicitudes
                    fixedWindow.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]!);
                    //Ventana de tiempo
                    fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]!));
                    //Maximo de peticiones que se encolan
                    fixedWindow.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]!); ;
                    //Orden de procesamiento de cola
                    fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });
                configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
            return services;
        }
    }
}
