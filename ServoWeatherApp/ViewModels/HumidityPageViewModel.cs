using ServoWeatherApp.Models;
using System.Collections.ObjectModel;

namespace ServoWeatherApp.ViewModels;

public class HumidityPageViewModel : BaseViewModel
{
    public ObservableCollection<TelemetryModel> telemetry { get; set; }
}