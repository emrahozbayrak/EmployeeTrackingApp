using Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Mobile.Services.Interfaces
{
    public interface ILocationService
    {
        Task<bool> SendLocationAsync(UserLocation userLocation);
    }
}
