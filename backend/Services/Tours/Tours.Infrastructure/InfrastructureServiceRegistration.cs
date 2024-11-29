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

namespace Tours.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToursDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("conStr")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseService<>));
            services.AddScoped(IToursRepository, ToursService);

            return services;
        }
    }
}
