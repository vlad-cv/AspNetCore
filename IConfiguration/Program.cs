
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapGet("/home", async (httpContext) =>
{
    string? clientId = app.Configuration["weatherapi:ClientId"];
    await httpContext.Response.WriteAsync($"Weather API Client Id: {clientId}\n");

    await httpContext.Response.WriteAsync($"Weather API Client Secret: {app.Configuration.GetValue<Guid>("weatherapi:ClientSecret").ToString()}\n");

    await httpContext.Response.WriteAsync($"Weather API Client Id: {app.Configuration.GetSection("weatherapi").GetValue<string>("ClientId", "Default value")}\n");

});

app.MapDefaultControllerRoute();

app.Run();
