using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entities;
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
    public class LocationController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public LocationController(IHistoryService historyService)
        {
            _historyService = historyService;
        }


        [HttpPost]
        public async Task<IActionResult> AddLocation(EmployeeHistory model)
        {
            await _historyService.AddHistoryAsync(model);

            return Ok();
        }
    }
}
