using Microsoft.EntityFrameworkCore;
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
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<EmployeeHistory> _employeeRepo;

        public HistoryService(IRepository<EmployeeHistory> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task AddHistoryAsync(EmployeeHistory employeeHistory)
        {
            await _employeeRepo.InsertAsync(employeeHistory);
        }

        public async Task<IEnumerable<EmployeeHistory>> GetHistoriesWithEmployeAsync(int Id)
        {
           return await _employeeRepo.Table
                 .Include(i => i.Employee)
                 .Include(i => i.StatusType)
                 .Where(p => p.EmployeeId == Id)
                 .OrderByDescending(o => o.LocationTime)
                 .ToListAsync();

        }

        public async Task<EmployeeHistory> GetHistoryWithEmployeAsync(int Id)
        {
            return await _employeeRepo.Table
                .Include(i => i.Employee)
                .Include(i => i.StatusType)
                .Where(p => p.Id == Id)
                .OrderByDescending(o => o.LocationTime)
                .FirstOrDefaultAsync();
        }
    }
}
