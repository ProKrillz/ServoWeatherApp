using CommunityToolkit.Mvvm.Input;
using ServoWeatherApp.Mapping;
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
        GetAllHumidityAsync().Wait();
    }

    public ObservableCollection<TelemetryModel> telemetry { get; set; }

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