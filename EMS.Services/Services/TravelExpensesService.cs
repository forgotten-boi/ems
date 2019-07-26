using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class TravelExpensesService : ApplicationService<TravelExpenses, int>, ITravelExpensesService
    {
        public TravelExpensesService(ITravelExpensesRepository TravelExpensesRepository) : base(TravelExpensesRepository)
        {

        }
    }
}