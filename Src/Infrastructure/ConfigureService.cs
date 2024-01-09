using Application.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //connection sql server
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
            //We dont need to implimment Generic Repository Scope But We must implimment UnitOfWork Pattern
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //connection stringRedis
            services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var options = ConfigurationOptions.Parse(configuration.GetConnectionString("RedisConnection"),true);
                return ConnectionMultiplexer.Connect(options);
            });
            return services;
        }
    }
}
