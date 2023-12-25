using Application;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Web_shop;

var builder = WebApplication.CreateBuilder(args);


//Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();

var app = builder.Build();
await app.AddWebappService().ConfigureAwait(false);
