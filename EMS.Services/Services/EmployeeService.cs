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
    public class TravelInfoService : ApplicationService<TravelInfo, int>, ITravelInfoService
    {
        public TravelInfoService(ITravelInfoRepository TravelInfoRepository) : base(TravelInfoRepository)
        {

        }
    }
    public class ApprovalInfoService : ApplicationService<ApprovalInfo, int>, IApprovalInfoService
    {
        public ApprovalInfoService(IApprovalRepository ApprovalInfoRepository) : base(ApprovalInfoRepository)
        {

        }
    }
    public class MiscExpensesService : ApplicationService<MiscExpenses, int>, IMiscExpensesService
    {
        public MiscExpensesService(IMiscExpensesRepository MiscExpensesRepository) : base(MiscExpensesRepository)
        {

        }
    }
    public class EntertainmentFBService : ApplicationService<EntertainmentFB, int>, IEntertainmentFBService
    {
        public EntertainmentFBService(IEntertainmentFBRepository EntertainmentFBRepository) : base(EntertainmentFBRepository)
        {

        }
    }
    public class TravelExpensesService : ApplicationService<TravelExpenses, int>, ITravelExpensesService
    {
        public TravelExpensesService(ITravelExpensesRepository TravelExpensesRepository) : base(TravelExpensesRepository)
        {

        }
    }
    public class MstExpensesService : ApplicationService<MstExpenses, int>, IMstExpensesService
    {
        public MstExpensesService(IMstExpensesRepository MstExpensesRepository) : base(MstExpensesRepository)
        {

        }
    }
   

}

