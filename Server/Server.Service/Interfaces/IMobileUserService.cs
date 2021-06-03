using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interfaces
{
    public interface IMobileUserService
    {
        Task<EmployeeModel> LoginAsync(MobileUserModel user);
    }
}
