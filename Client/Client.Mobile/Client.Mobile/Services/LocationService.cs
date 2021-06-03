using Client.Mobile.Models;
using Client.Mobile.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Mobile.Services
{
    public class LocationService : BaseClient, ILocationService
    {
        public LocationService()
        {

        }
        public async Task<bool> SendLocationAsync(UserLocation userLocation)
        {
            if (!GetConnectionStatus()) return false;

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            var json = await Client.PostAsync("api/location", new StringContent(JsonConvert.SerializeObject(userLocation), Encoding.UTF8, "application/json"));

            if (json.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }


            return false;
        }
    }
}
