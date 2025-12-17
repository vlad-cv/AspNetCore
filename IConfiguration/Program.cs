using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapGet("/home", async (httpContext) => {
    string? clientId = app.Configuration["weatherapi:ClientId"];
    await httpContext.Response.WriteAsync($"Weather API Client ID: {clientId}");
});

app.MapDefaultControllerRoute();

app.Run();
