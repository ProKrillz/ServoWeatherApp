using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using ServoWeatherApp.Mapping;
using ServoWeatherApp.Models;
using ServoWeatherDomain.API.Entities;
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

    public ObservableCollection<TelemetryModel> telemetry { get; set; } = [];

    [RelayCommand]
    public async Task GetAllTemperature()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            List<Telemetry> items = [];
            items = await _service.GetItemsAsync(1);
            if (telemetry.Any())
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