using Ecommerce.Application.Interface;
using Ecommerce.Application.Main;
using Ecommerce.Domain.Core;
using Ecommerce.Domain.Interface;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Interface;
using Ecommerce.Infraestructure.Repository;
using Ecommerce.Transversal.Common;
using Ecommerce.Transversal.Logging;

namespace Ecommerce.Services.WebApi.Modules.Inyection
{
    public static class InyectionExtensions
    {
        public static IServiceCollection AddInyections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
