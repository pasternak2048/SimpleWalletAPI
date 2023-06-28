using Application;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Context;
using Persistence.Models;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureAutoMapperServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
var services = serviceScope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    //await dataContext?.Database.MigrateAsync();
    await Seed.SeedUsers(userManager, roleManager);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.Run();