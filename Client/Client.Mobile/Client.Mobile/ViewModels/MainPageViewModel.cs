using Client.Mobile.Helpers;
using Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Client.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command<string> SendCommand { get; }

        public MainPageViewModel()
        {
            SendCommand = new Command<string>(async (parameter) => await ExecuteLoadOrdersCommand(parameter));
        }

        async Task ExecuteLoadOrdersCommand(string parameter)
        {
            try
            {
                IsBusy = true;
                int status = Int16.Parse(parameter);
                string latitude = "";
                string longitude = "";
                
                if (status != (short)StatusTypes.Izinli) // eğer çalışan izinli ise konum gönderimi yapılmayacak.
                {
                    var location = await GetLocation();
                    latitude = location.Latitude.ToString();
                    longitude = location.Longitude.ToString();

                    if (location == null) { await App.Current.MainPage.DisplayAlert("Uyarı", "Konum bilgisi alınamadı. Lütfen Tekrar deneyin.", "OK"); return; }
                }


                var userId = await SecureStorage.GetAsync("id");// UserId bilgisi alınıyor.

                var userLocation = new UserLocation
                {
                    EmployeeId = Int32.Parse(userId),
                    LocationTime = DateTime.Now,
                    StatusTypeId = Int16.Parse(parameter),
                    Latitude = latitude,
                    Longitude = longitude
                };

                await LocationDataStore.SendLocationAsync(userLocation);
                await App.Current.MainPage.DisplayAlert("Uyarı", "İşlem Başarılı", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Başarısız", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Konum bilgisi alınıyor.
        private async Task<Location> GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var location = await Geolocation.GetLocationAsync(request);

            if (location == null) return null;

            return location;
        }

    }
}
