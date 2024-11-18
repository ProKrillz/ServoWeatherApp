using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp.Views;

public partial class HumidityPage : ContentPage
{
    HumidityPageViewModel _vm;
	public HumidityPage(HumidityPageViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
		BindingContext = _vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _vm.GetAllHumidityCommand.Execute(null);
    }
}