using AuthUserToken.Domain.Interface.Authentication;
using AuthUserToken.Domain.Interface.Repository;
using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Serivce;
using AuthUserToken.Infrastructure.Authentication;
using AuthUserToken.Infrastructure.Context;
using AuthUserToken.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthUserToken.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("ConnectionSqlite")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
