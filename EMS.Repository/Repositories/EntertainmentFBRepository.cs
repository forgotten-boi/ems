using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class EntertainmentFBRepository : Repository<EntertainmentFB, int>, IEntertainmentFBRepository
    {
        public EntertainmentFBRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}