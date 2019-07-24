using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Repository.Irepositories;
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

    public interface IEmployeeRepository : IRepository<EmployeeInfo, int>
    {

    }
    public class TravelInfoRepository : Repository<TravelInfo, int>, ITravelInfoRepository
    {
        public TravelInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface ITravelInfoRepository : IRepository<TravelInfo, int>
    {

    }
    public class ApprovalRepository : Repository<ApprovalInfo, int>, IApprovalRepository
    {
        public ApprovalRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IApprovalRepository : IRepository<ApprovalInfo, int>
    {

    }
    public class MiscExpensesRepository : Repository<MiscExpenses, int>, IMiscExpensesRepository
    {
        public MiscExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IMiscExpensesRepository : IRepository<MiscExpenses, int>
    {

    }
    public class EntertainmentFBRepository : Repository<EntertainmentFB, int>, IEntertainmentFBRepository
    {
        public EntertainmentFBRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IEntertainmentFBRepository : IRepository<EntertainmentFB, int>
    {

    }
    public class TravelExpensesRepository : Repository<TravelExpenses, int>, ITravelExpensesRepository
    {
        public TravelExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface ITravelExpensesRepository : IRepository<TravelExpenses, int>
    {

    }
    public class MstExpensesRepository : Repository<MstExpenses, int>, IMstExpensesRepository
    {
        public MstExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IMstExpensesRepository : IRepository<MstExpenses, int>
    {

    }
}
