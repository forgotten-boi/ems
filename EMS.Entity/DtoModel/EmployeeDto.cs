using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public class TravelDto 
    {
        public TravelDto()
        {
            this.TravelExpensesDtos = new List<TravelExpenseDto>();
        }

        [Key]
        public int TravelId { get; set; }
     
        [Required]
        [Display(Name ="First Name")]
        public string EmployeeFName { get; set; }
        [Display(Name = "Last Name")]
        public string EmployeeLName { get; set; }

        public string Destination { get; set; }
        public string Purpose { get; set; }

        public IFormFile RecieptFile { get; set; }
        public string RecieptDoc { get; set; }
        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string Department { get; set; }
        public string Currency { get; set; }

        private DateTime UpdateDate;

       

        public DateTime Date
        {
            get { return UpdateDate; }
            set { UpdateDate = DateTime.Now; }
        }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public bool? IsApproved { get; set; }

        public string GetApproval
        {
            get
            {
                switch (IsApproved)
                {
                    case true:
                        return "Approved";
                    case false:
                        return "Rejected";
                    case null:
                        return "Pending";
                    default:
                        return "pending";
                }
            }

        }

        public ICollection<TravelExpenseDto> TravelExpensesDtos { get; set; }

    }

    public class ApprovalDto
    {
        public int ApprovalId { get; set; }

        [ForeignKey("TravelInfo")]
        public int TravelID { get; set; }
 

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string Comment { get; set; }
        public DateTime ApprovedDate { get; set; }

        public double TotalExpenses { get; set; }
    }

    public class MiscExpenseDto
    {
        [Key]
        public int MiscExpId { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }

    public class EntertainmentFBDto
    {
        [Key]
        public int EntertainmentFBId { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }

    public class TravelExpenseDto
    {
        [Key]
        public int TravelExpId { get; set; }
        public int TravelID { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public double Expenses { get; set; }
    }

    public class MstExpenseDto 
    {
        [Key]
        public int MstExpId { get; set; }
        public string Comment { get; set; }
        public int Order { get; set; }
    }
}
