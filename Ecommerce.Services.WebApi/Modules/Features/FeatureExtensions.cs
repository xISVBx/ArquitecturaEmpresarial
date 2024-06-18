namespace Ecommerce.Services.WebApi.Modules.Features
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
            .AllowAnyHeader()
            .AllowAnyMethod()));

            return services;
        }
    }
}
