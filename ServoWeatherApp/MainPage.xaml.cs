using ServoWeatherApp.ViewModels;

namespace ServoWeatherApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
