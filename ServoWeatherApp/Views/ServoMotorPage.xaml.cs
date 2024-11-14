using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class ServoMotorPage : ContentPage
{
	ServoMotorPageViewModel _vm;
	public ServoMotorPage(ServoMotorPageViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;

	}
}