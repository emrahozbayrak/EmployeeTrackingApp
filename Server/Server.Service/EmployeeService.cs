using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Data.Entities;
using Server.Repository;
using Server.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            var data = await _employeeRepo.TableNoTracking.Where(p => !p.IsDeleted).OrderBy(o => o.Name).ToListAsync();
            var mappedData = _mapper.Map<List<EmployeeModel>>(data);

            return mappedData;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByNameAsync(string Name)
        {
            var data = await _employeeRepo.TableNoTracking.Where(p => !p.IsDeleted && p.Name.Contains(Name)).OrderBy(o => o.Name).ToListAsync();
            var mappedData = _mapper.Map<List<EmployeeModel>>(data);

            return mappedData;
        }
        public async Task<EmployeeModel> GetEmployeeAsync(int Id)
        {
            var data = await _employeeRepo.GetByIdAsync(Id);
            var mappedData = _mapper.Map<EmployeeModel>(data);

            return mappedData;
        }
        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            var mappedData = _mapper.Map<Employee>(employee);

            await _employeeRepo.InsertAsync(mappedData);
        }

        public void DeleteEmployee(EmployeeModel employee)
        {
            var mappedData = _mapper.Map<Employee>(employee);

            _employeeRepo.Delete(mappedData);
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            var data = _employeeRepo.GetById(employee.Id);
            var mappedData = _mapper.Map<Employee>(employee);

            _employeeRepo.UpdateMatchEntity(data, mappedData);
        }

    }
}
