using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class EmployeeService : ApplicationService<EmployeeInfo, int>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }
    }
}

