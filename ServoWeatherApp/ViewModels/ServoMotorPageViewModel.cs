using CommunityToolkit.Mvvm.Input;
using ServoWeatherService.Services.Interfaces;

namespace ServoWeatherApp.ViewModels;

public partial class ServoMotorPageViewModel(ITelemetryService _service) : BaseViewModel
{
    //Turn on the servo motor 180*.
    [RelayCommand]
    public void TurnOn()
    {
        _service.ServoMotor("on");
    }

    //Turn Off the servo motor 180*.
    [RelayCommand]
    public void TurnOff()
    {
        _service.ServoMotor("off");
    }
}