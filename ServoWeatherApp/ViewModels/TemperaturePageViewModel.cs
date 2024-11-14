using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using ServoWeatherApp.Models;
using ServoWeatherService.Services.Interfaces;
using System.Collections.ObjectModel;

namespace ServoWeatherApp.ViewModels;

public partial class TemperaturePageViewModel : BaseViewModel
{
    private readonly ITelemetryService _service;
    public TemperaturePageViewModel(ITelemetryService service)
    {
        _service = service;
    }

    public ObservableCollection<TelemetryModel> Telemetry { get; set; }

    [RelayCommand]
    public async Task GetAllHumidityAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            var items = await _service.GetItemsAsync(); ;
            List<int> tal = new();
            if (Telemetry.Count != 0)
                Telemetry.Clear();

            foreach (var item in items)
                Telemetry.Add(item);
        }
        catch (Exception ex)
        {

            throw;
        }
        finally
        {
            IsBusy = false;
        }
    }
}