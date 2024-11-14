using CommunityToolkit.Mvvm.ComponentModel;

namespace ServoWeatherApp.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string? title;

    [ObservableProperty]
    bool isBusy = false;

    [ObservableProperty]
    bool isRefreashing = false;
}