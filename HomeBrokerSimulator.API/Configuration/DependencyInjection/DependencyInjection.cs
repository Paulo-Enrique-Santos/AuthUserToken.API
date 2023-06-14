using HomeBrokerSimulator.Infrastructure.Authentication;
using HomeBrokerSimulator.Infrastructure.Context;
using HomeBrokerSimulator.Infrastructure.Interface.Authentication;
using HomeBrokerSimulator.Infrastructure.Interface.Repository;
using HomeBrokerSimulator.Infrastructure.Repositories;
using HomeBrokerSimulator.Service.Interface;
using HomeBrokerSimulator.Service.Serivces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace HomeBrokerSimulator.API.Configuration.DependencyInjection
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

        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoAuthentication.API"));
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });
        }

        public static void AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Autenticação",
                    Description = "Essa é uma API de cadastro e login que gera um token para autenticação."
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Autenticação em JWT. Ex: Bearer {Token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
                var assembly = Assembly.GetEntryAssembly();
                var assemblyName = assembly.GetName().Name;
                var xmlFilename = $"{assemblyName}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
