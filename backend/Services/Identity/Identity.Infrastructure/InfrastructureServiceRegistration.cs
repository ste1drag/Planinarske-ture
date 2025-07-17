using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Identity.Infrastructure.Services;
using Identity.Application.Contracts;

namespace Identity.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        private static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityDB"),
                sql => sql.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

        private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User,IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection ConfigureJWT(this IServiceCollection services, IConfiguration configuration) 
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        private static IServiceCollection ConfigureMiscellaneousServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistence(configuration);
            services.ConfigureIdentity();
            services.ConfigureJWT(configuration);
            services.ConfigureMiscellaneousServices();

            return services;
        }
    }
}
