using Ecommerce.Application.Validator;

namespace Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
                
            return services;
        }
    }
}
