using AutoMapper;
using Server.Core.Models;
using Server.Data.Entities;
using Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region MobileUser Mapping
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
            #endregion
        }
    }
}
