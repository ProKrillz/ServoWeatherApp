using CommunityToolkit.Mvvm.Input;
using ServoWeatherApp.Mapping;
using ServoWeatherApp.Models;
using ServoWeatherDomain.API.Entities;
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

    public ObservableCollection<TelemetryModel> telemetry { get; set; } = []; // Its lowercase because of MVVM nugget.

    [RelayCommand]
    public async Task GetAllHumidity()
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