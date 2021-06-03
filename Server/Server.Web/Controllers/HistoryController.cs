using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Service;
using Server.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Server.Web.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        public async Task<IActionResult> Index(int Id, int page = 1)
        {
            var dataList = await _historyService.GetHistoriesWithEmployeAsync(Id);

            var pagedData = dataList.ToPagedList(page, 10);

            return View(pagedData);
        }

        public async Task<IActionResult> ShowMap(int Id)
        {
            var data = await _historyService.GetHistoryWithEmployeAsync(Id);

            return View(data);
        }
    }
}
