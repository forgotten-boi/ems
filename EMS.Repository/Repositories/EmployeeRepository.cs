using EMS.DataAccess;
using EMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Repository.Repositories
{
    public class EmployeeRepository : Repository<EmployeeInfo, int>, IEmployeeRepository
    {
        public EmployeeRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}
