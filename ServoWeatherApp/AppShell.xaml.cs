using ServoWeatherApp.Views;

namespace ServoWeatherApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HumidityPage), typeof(HumidityPage));
            Routing.RegisterRoute(nameof(ServoMotorPage), typeof(ServoMotorPage));
            Routing.RegisterRoute(nameof(TemperaturePage), typeof(TemperaturePage));
        }
    }
}
