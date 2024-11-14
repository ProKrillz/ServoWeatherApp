using Microsoft.Extensions.Logging;
using ServoWeatherApp.ViewModels;
using ServoWeatherApp.Views;
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

            builder.Services.AddSingleton<TemperaturePage>();
            builder.Services.AddSingleton<TemperaturePageViewModel>();

            builder.Services.AddSingleton<HumidityPage>();
            builder.Services.AddSingleton<HumidityPageViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
