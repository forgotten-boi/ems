using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class MstExpensesService : ApplicationService<MstExpenses, int>, IMstExpensesService
    {
        public MstExpensesService(IMstExpensesRepository MstExpensesRepository) : base(MstExpensesRepository)
        {

        }
    }
}