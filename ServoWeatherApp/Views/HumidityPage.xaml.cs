using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class HumidityPage : ContentPage
{
	public HumidityPage(HumidityPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}