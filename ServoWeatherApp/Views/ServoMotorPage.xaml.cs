using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class ServoMotorPage : ContentPage
{
	public ServoMotorPage(ServoMotorPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}
}