using EMS.Entity.DtoModel;
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
    public interface IApprovalInfoService : IApplicationService<ApprovalInfo, int>
    {
    }
    public interface ITravelInfoService : IApplicationService<TravelInfo, int>
    {
    }
    public interface IMiscExpensesService : IApplicationService<MiscExpenses, int>
    {
    }
    public interface IEntertainmentFBService : IApplicationService<EntertainmentFB, int>
    {
    }
    public interface ITravelExpensesService : IApplicationService<TravelExpenses, int>
    {
    }
    public interface IMstExpensesService : IApplicationService<MstExpenses, int>
    {
    }
}
