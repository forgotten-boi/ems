using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class MstExpensesRepository : Repository<MstExpenses, int>, IMstExpensesRepository
    {
        public MstExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}