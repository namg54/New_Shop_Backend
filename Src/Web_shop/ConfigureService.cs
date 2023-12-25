using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Web_shop
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Services;
        }
        public static async Task<IApplicationBuilder> AddWebappService(this WebApplication app)
        {

            //Create Scope
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            //Get Service
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var context = services.GetRequiredService<ApplicationDbContext>();

            //Auto Migrations
            try
            {
                await context.Database.MigrateAsync();
                await GenerateSeedData.SeedDataAsync(context, loggerFactory);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(e, "Error Exception Migrations");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
            return app;
        }

    }


}
