using Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interfaces
{
    public interface IHistoryService
    {
        Task<EmployeeHistory> GetHistoryWithEmployeAsync(int Id);
        Task<IEnumerable<EmployeeHistory>> GetHistoriesWithEmployeAsync(int Id);

        Task AddHistoryAsync(EmployeeHistory employeeHistory);
    }
}
