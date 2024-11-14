using CommunityToolkit.Mvvm.Input;
using ServoWeatherApp.Views;

namespace ServoWeatherApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [RelayCommand]
    public async Task GoToTemperature()
    {
        await Shell.Current.GoToAsync(nameof(TemperaturePage));
    }

    [RelayCommand]
    public async Task GoToHumidity()
    {
        await Shell.Current.GoToAsync(nameof(HumidityPage));
    }

    [RelayCommand]
    public async Task GoToServoMotor()
    {
        await Shell.Current.GoToAsync(nameof(ServoMotorPage));
    }
}
