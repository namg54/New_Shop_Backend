using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Web_shop.Middleware;

namespace Web_shop
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder, IConfiguration configuration)
        {

            // Add services to the container.
            builder.Services.AddControllers();

            ApiBehaviorOption(builder);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", Policy =>
                {
                    Policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(configuration["CorsAddress:AddressHttp"], configuration["CorsAddress:AddressHttps"]);
                });
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            return builder.Services;
        }

        private static void ApiBehaviorOption(WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(v => v.Value.Errors)
                    .Select(c => c.ErrorMessage).ToList();
                    return new BadRequestObjectResult(new ApiToReturn(400, errors.ToList()));
                };

            });
        }

        public static async Task<IApplicationBuilder> AddWebappService(this WebApplication app)
        {
            app.UseMiddleware<Middleware_ExceptionHandler>();

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
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
            return app;
        }

    }


}
