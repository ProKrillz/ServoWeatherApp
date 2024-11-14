
using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class TemperaturePage : ContentPage
{
	public TemperaturePage(TemperaturePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}