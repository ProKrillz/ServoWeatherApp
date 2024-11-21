using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using ServoWeatherDomain.GenericRepositories;
using ServoWeatherService.Services;
using ServoWeatherService.Services.Interfaces;
using ServoWeatherWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<ITelemetryService, TelemetryService>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();

builder.Services.AddMudServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ServoWeatherWeb.Client._Imports).Assembly);

app.Run();
