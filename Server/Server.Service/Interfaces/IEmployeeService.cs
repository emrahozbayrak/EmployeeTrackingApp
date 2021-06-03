
using Server.Core.Models;
using Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployeeAsync(int Id);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByNameAsync(string Name);
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeModel employee);
        void UpdateEmployee(EmployeeModel employee);
        void DeleteEmployee(EmployeeModel employee);
    }
}
