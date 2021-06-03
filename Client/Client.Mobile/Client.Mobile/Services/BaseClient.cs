using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace Client.Mobile.Services
{
   public class BaseClient
    {
        public HttpClient Client { get; set; }
        public Guid DriverId { get; }
        public BaseClient()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            Client = new HttpClient(insecureHandler);
            Client.BaseAddress = new Uri($"{App.BackendUrl}/");
          
        }

        // Localhost için Ssl güvenlik denetimi devredışı bırakılıyor.
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        // İnternet bağlantı kontrolü
        public bool GetConnectionStatus()
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                App.Current.MainPage.DisplayAlert("Hata", "İnternet bağlantınızı kontrol edip yeniden deneyin.", "OK");
                return false;
            }

            return true;
        }
    }
}
