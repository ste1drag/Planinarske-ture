using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Application.Contracts;
using Tours.Application.Repositories;
using Tours.Infrastructure.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tours.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ToursDB") ?? throw new InvalidOperationException("Connection string 'ToursDB' not found.");

            services.AddDbContext<ToursDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseService<>));
            services.AddScoped(typeof(IToursRepository), typeof(ToursService));

            return services;
        }
    }
}
