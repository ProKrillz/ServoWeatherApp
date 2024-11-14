using CommunityToolkit.Mvvm.Input;
using ServoWeatherService.Services.Interfaces;

namespace ServoWeatherApp.ViewModels;

public partial class ServoMotorPageViewModel : BaseViewModel
{
	private readonly ITelemetryService _service;

    public ServoMotorPageViewModel(ITelemetryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Styring af servo motor med en input ( "On" or "Off" ).
    /// </summary>
    /// <param name="input"></param>
    [RelayCommand]
    public void ServoControlAsync(string input)
    {
        _service.ServoMotor(input);
    }
}