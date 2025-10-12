using MassTransit;
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
using Tours.Domain.Entities;
using Tours.Infrastructure.Configurations;
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
                options.UseSqlServer(connectionString)
                        .UseSeeding((_context, _) =>
                        {
                            _context.Set<Mountain>().AddRange(SeedData.AddMountains());
                            _context.SaveChanges();
                        }));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseService<>));
            services.AddScoped(typeof(IMountainRepository), typeof(MounainService));
            services.AddScoped(typeof(IToursRepository), typeof(ToursService));

            // Configure RabbitMQ settings
            var rabbitMqSettings = new RabbitMqSettings
            {
                Host = configuration["RabbitMq:Host"] ?? "localhost",
                VirtualHost = configuration["RabbitMq:VirtualHost"] ?? "/",
                Username = configuration["RabbitMq:Username"] ?? "guest",
                Password = configuration["RabbitMq:Password"] ?? "guest",
                Port = ushort.Parse(configuration["RabbitMq:Port"] ?? "5672")
            };
            // Configure MassTransit with RabbitMQ
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqSettings.Host, rabbitMqSettings.VirtualHost, h =>
                    {
                        h.Username(rabbitMqSettings.Username);
                        h.Password(rabbitMqSettings.Password);
                    });
                });
            });
            return services;
        }
    }
}
