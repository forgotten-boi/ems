using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
    public class MstExpenses : BaseEntity<int>
    {
        public string Comment { get; set; }
        public int Order { get; set; }
    }
}