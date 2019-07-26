using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class TravelInfoService : ApplicationService<TravelInfo, int>, ITravelInfoService
    {
        public TravelInfoService(ITravelInfoRepository TravelInfoRepository) : base(TravelInfoRepository)
        {

        }
    }
}