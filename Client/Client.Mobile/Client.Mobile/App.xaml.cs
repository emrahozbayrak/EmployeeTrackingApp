using Client.Mobile.Services;
using Client.Mobile.ViewModels;
using Client.Mobile.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client.Mobile
{
    public partial class App : Application
    {
        // Android emulatorlerde localhost çalışmadığı için ip ataması yapılıyor.
        // Daha detaylı bilgi için https://docs.microsoft.com/tr-tr/xamarin/cross-platform/deploy-test/connect-to-local-web-services
        // Port bilgilerini projenizin çalıştığı port numarası ile değiştirin.
        public static string BackendUrl =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<LoginService>();
            DependencyService.Register<LocationService>();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
