using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class MiscExpensesRepository : Repository<MiscExpenses, int>, IMiscExpensesRepository
    {
        public MiscExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}