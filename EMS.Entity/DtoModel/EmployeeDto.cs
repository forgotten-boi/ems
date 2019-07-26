using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entity.DtoModel
{
    public class EmployeeDto
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
