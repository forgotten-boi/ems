using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class EntertainmentFBService : ApplicationService<EntertainmentFB, int>, IEntertainmentFBService
    {
        public EntertainmentFBService(IEntertainmentFBRepository EntertainmentFBRepository) : base(EntertainmentFBRepository)
        {

        }
    }
}