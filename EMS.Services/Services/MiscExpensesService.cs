using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Repositories;
using EMS.Services.IServices;

namespace EMS.Services.Services
{
    public class MiscExpensesService : ApplicationService<MiscExpenses, int>, IMiscExpensesService
    {
        public MiscExpensesService(IMiscExpensesRepository MiscExpensesRepository) : base(MiscExpensesRepository)
        {

        }
    }
}