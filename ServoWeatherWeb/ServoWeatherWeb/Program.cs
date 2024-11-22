using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using ServoWeatherDomain.GenericRepositories;
using ServoWeatherService.Services;
using ServoWeatherService.Services.Interfaces;
using ServoWeatherWeb.Components;
using MudBlazor.Services;
using Microsoft.AspNetCore.Identity;
using ServoWeatherService.Services;
using ServoWeatherService.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using ServoWeatherDomain.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


var connectionString = builder.Configuration
    .GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)).AddLogging();

builder.Services.AddIdentityCore<IdentityUser>()
                .AddSignInManager()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddMudServices();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Read", x => x.RequireClaim("ReadAccess"));
    option.AddPolicy("Write", x => x.RequireClaim("WriteAccess"));
});

builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme) //IdentityConstants.ApplicationScheme
    .AddIdentityCookies();

//builder.Services.AddApiAuthorization();

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

app.UseAuthentication(); // auth
app.UseAuthorization();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ServoWeatherWeb.Client._Imports).Assembly);

app.Run();
