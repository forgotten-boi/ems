using EMS.DataAccess;
using EMS.Entity.Entities;

namespace EMS.Repository.Repositories
{
    public class ApprovalRepository : Repository<ApprovalInfo, int>, IApprovalRepository
    {
        public ApprovalRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }
}