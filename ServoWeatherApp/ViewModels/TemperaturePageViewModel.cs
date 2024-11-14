using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using ServoWeatherApp.Mapping;
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
        GetAllTemperatureAsync().Wait();
    }

    public ObservableCollection<TelemetryModel> telemetry { get; set; }

    [RelayCommand]
    public async Task GetAllTemperatureAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            var items = await _service.GetItemsAsync(1); ;
            List<int> tal = new();
            if (telemetry.Count != 0)
                telemetry.Clear();

            foreach (var item in items)
                telemetry.Add(item.ConvertFromEntityToModel());
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