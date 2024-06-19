using HealthChecks.UI.Core;

namespace Ecommerce.Services.WebApi.Modules.HealthChecks
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddDiskStorageHealthCheck(setup =>
                {
                    setup.AddDrive("C:\\", minimumFreeMegabytes: 1000); // Configura la unidad C: con un mínimo de 1000 MB libres
                })
                .AddPrivateMemoryHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024);

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();

            return services;
        }
    }
}
