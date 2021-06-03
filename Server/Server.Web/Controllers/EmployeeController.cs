using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Data;
using Server.Data.Entities;
using Server.Service;
using Server.Service.Interfaces;
using Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Server.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            IEnumerable<EmployeeModel> dataList;
            if (!string.IsNullOrEmpty(search))
                dataList = await _employeeService.GetEmployeesByNameAsync(search);
            else
                dataList = await _employeeService.GetAllEmployeesAsync();


            var pagedData = dataList.ToPagedList(page, 10);

            return View(pagedData);
        }


        //GET: Employee/AddOrEdit(Insert)
        //GET: Employee/AddOrEdit/5(Update)
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeModel());
            else
            {
                var data = await _employeeService.GetEmployeeAsync(id);
                if (data == null)
                {
                    return NotFound();
                }

                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _employeeService.AddEmployeeAsync(model);

                }
                //Update
                else
                {
                    _employeeService.UpdateEmployee(model);
                }

                return RedirectToAction("Index");
            }
            return View("AddOrEdit", model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _employeeService.GetEmployeeAsync(Id);
            data.IsDeleted = true;

            _employeeService.UpdateEmployee(data);

            return RedirectToAction("Index");
        }

    }
}
