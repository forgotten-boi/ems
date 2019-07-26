using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class TravelExpensesRepository : Repository<TravelExpenses, int>, ITravelExpensesRepository
    {
        public TravelExpensesRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}