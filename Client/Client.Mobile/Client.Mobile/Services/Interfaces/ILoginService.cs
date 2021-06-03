using Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Mobile.Services.Interfaces
{
    public interface ILoginService
    {
        Task<User> LoginAsync(UserRequest user);
    }
}
