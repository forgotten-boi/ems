using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class TravelInfoRepository : Repository<TravelInfo, int>, ITravelInfoRepository
    {
        public TravelInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}