
using IConfigurationExample.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configuration as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi"));

// Load MyOwnConfig.json
// This is the .NET Core 3.1 - 5.0 style. It still works but it is more verbose.
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
//});

// Load MyOwnConfig.json
//Modern way .NET 6+ style - cleaner and direct
builder.Configuration.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);

var app = builder.Build();

app.MapGet("/", async (httpContext) =>
{
    string? clientId = app.Configuration["weatherapi:ClientId"];
    await httpContext.Response.WriteAsync($"Weather API Client Id: {clientId}\n");

    await httpContext.Response.WriteAsync($"Weather API Client Secret: {app.Configuration.GetValue<Guid>("weatherapi:ClientSecret").ToString()}\n");

    await httpContext.Response.WriteAsync($"Weather API Client Id: {app.Configuration.GetSection("weatherapi").GetValue<string>("ClientId", "Default value")}\n");

});



app.MapDefaultControllerRoute();

app.Run();
