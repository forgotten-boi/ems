using EMS.Entity.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entity.Entities
{
    public class EmployeeInfo : BaseEntity<int>
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
     
    }
}
