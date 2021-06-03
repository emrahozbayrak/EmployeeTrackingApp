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
    public class MobileUserService : IMobileUserService
    {
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;

        public MobileUserService(IRepository<Employee> employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<EmployeeModel> LoginAsync(MobileUserModel user)
        {
            var data = await _employeeRepo.Table
                      .Where(p => !p.IsDeleted && p.MobileUsername == user.Username && p.MobilePassword == user.Password)
                      .FirstOrDefaultAsync();
            if (data == null) return null;

            return _mapper.Map<EmployeeModel>(data);
        }
    }
}
