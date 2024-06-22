using HealthChecks.UI.Core;

namespace Ecommerce.Services.WebApi.Modules.HealthChecks
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddRedis(configuration.GetConnectionString("RedisConnection"), tags: new[] { "cache" })
                .AddDiskStorageHealthCheck(setup =>
                {
                    setup.AddDrive("C:\\", minimumFreeMegabytes: 1000); // Configura la unidad C: con un mínimo de 1000 MB libres
                }, tags: new[] { "disk" })
                .AddPrivateMemoryHealthCheck(maximumMemoryBytes: 1024 * 1024 * 1024, tags: new[] { "memory" });

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();

            return services;
        }
    }
}
