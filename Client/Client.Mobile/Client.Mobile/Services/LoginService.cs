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
    public class LoginService : BaseClient, ILoginService
    {
        public LoginService()
        {

        }
        public async Task<User> LoginAsync(UserRequest user)
        {
            if (!GetConnectionStatus()) return null;

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            var json = await Client.PostAsync("api/mobileauth", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            if (json.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await json.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<User>(content);
                return result;
            }


            return null;
        }
    }
}
