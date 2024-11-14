namespace ServoWeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3NzMxMkAzMjM3MmUzMDJlMzBKZlVkY204ZWVWZ20wQUk0VVhIRkR5Q3JFcGNsbVlyVVQ2Q3JjUXQwN0ZjPQ==");
            MainPage = new AppShell();
        }
    }
}
