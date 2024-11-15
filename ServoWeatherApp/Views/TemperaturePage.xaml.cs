
using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class TemperaturePage : ContentPage
{
	TemperaturePageViewModel _vm;
	public TemperaturePage(TemperaturePageViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}

    protected override void OnAppearing()
	{
        base.OnAppearing();
        _vm.GetAllTemperatureCommand.Execute(null);
	}

}