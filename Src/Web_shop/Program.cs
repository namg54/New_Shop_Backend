using Application;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Web_shop;
using Web_shop.Middleware;

var builder = WebApplication.CreateBuilder(args);


//Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection(builder.Configuration);

var app = builder.Build();
//Access To Wwwroot
await app.AddWebappService().ConfigureAwait(false);
