using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics.Text;
using ServoWeatherApp.Models;
using System.Collections.ObjectModel;

namespace ServoWeatherApp.ViewModels;

public partial class TemperaturePageViewModel : BaseViewModel
{
    public ObservableCollection<TelemetryModel> telemetry { get; set; }

    public TemperaturePageViewModel()
    {
        
    }
}