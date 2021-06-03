using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Core.Models;
using Server.Service;
using Server.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileAuthController : ControllerBase
    {
        private readonly IMobileUserService _userService;
        public MobileAuthController(IMobileUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(MobileUserModel model)
        {
            var result = await _userService.LoginAsync(model);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
