using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.DtoModel
{
    public class MstExpenseDto 
    {
        [Key]
        public int MstExpId { get; set; }
        public string Comment { get; set; }
        public int Order { get; set; }
    }
}