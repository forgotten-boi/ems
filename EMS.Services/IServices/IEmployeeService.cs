﻿using EMS.Entity.DtoModel;
using EMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.IServices
{
    public interface IEmployeeService : IApplicationService<EmployeeInfo, int>
    {
    }
}
