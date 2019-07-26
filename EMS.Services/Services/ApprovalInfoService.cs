using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class ApprovalInfoService : ApplicationService<ApprovalInfo, int>, IApprovalInfoService
    {
        public ApprovalInfoService(IApprovalRepository ApprovalInfoRepository) : base(ApprovalInfoRepository)
        {

        }
    }
}