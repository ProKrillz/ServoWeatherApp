using Microsoft.Extensions.Logging;
using ServoWeatherApp.ViewModels;
using ServoWeatherApp.Views;
using ServoWeatherDomain.GenericRepositories;
using ServoWeatherService.Services;
using ServoWeatherService.Services.Interfaces;
using Syncfusion.Maui.Core.Hosting;

namespace ServoWeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            
            builder.Services.AddSingleton<ITelemetryService, TelemetryService>();
            builder.Services.AddSingleton<IGenericRepository, GenericRepository>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();


            builder.Services.AddTransient<TemperaturePage>();
            builder.Services.AddTransient<TemperaturePageViewModel>();

            builder.Services.AddTransient<HumidityPage>();
            builder.Services.AddTransient<HumidityPageViewModel>();

            builder.Services.AddTransient<ServoMotorPage>();
            builder.Services.AddTransient<ServoMotorPageViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
