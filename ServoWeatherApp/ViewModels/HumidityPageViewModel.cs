using CommunityToolkit.Mvvm.Input;
using ServoWeatherApp.Models;
using ServoWeatherService.Services.Interfaces;
using System.Collections.ObjectModel;

namespace ServoWeatherApp.ViewModels;

public partial class HumidityPageViewModel : BaseViewModel
{
    private readonly ITelemetryService _service;

    public HumidityPageViewModel(ITelemetryService service)
    {
        _service = service;
    }

    public ObservableCollection<TelemetryModel> telemetry { get; set; }

    [RelayCommand]
    public async Task GetAllHumidityAsync()
    {

    }
}