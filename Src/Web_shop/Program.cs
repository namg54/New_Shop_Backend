using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Web_shop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Configurations
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();

var app = builder.Build();
//Create Scope
var scope = app.Services.CreateScope();
var services=scope.ServiceProvider;
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

app.Run();
