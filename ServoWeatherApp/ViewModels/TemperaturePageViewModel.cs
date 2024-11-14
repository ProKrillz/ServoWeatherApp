using CommunityToolkit.Mvvm.ComponentModel;
using ServoWeatherApp.Models;

namespace ServoWeatherApp.ViewModels;

public class TemperaturePageViewModel : ObservableObject
{
    public List<TelemetryModel> telemetry { get; set; }

    public TemperaturePageViewModel()
    {
        telemetry = new List<TelemetryModel>()
        {
            new TelemetryModel { Humidity = 40.5 , Temperature = 45.3},
            new TelemetryModel { Humidity = 45.5 , Temperature = 46.3},
            new TelemetryModel { Humidity = 35.5 , Temperature = 47.3},
            new TelemetryModel { Humidity = 37.5 , Temperature = 43.3},
            new TelemetryModel { Humidity = 50.5 , Temperature = 33.3}
        };
    }
}