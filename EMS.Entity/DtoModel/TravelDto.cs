using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EMS.Entity.DtoModel
{
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
        [Required]
        public string EmployeeLName { get; set; }

        [Required]
        public string Destination { get; set; }
        public string Purpose { get; set; }

        public IFormFile RecieptFile { get; set; }
        public string RecieptDoc { get; set; }
        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string Department { get; set; }
        public string Currency { get; set; }
        public double TotalExpenses { get; set; }

        private DateTime UpdateDate;


        [DataType(DataType.Date)]
        public DateTime Date
        {
            get { return UpdateDate; }
            set { UpdateDate = value == default ? DateTime.Now : value; }
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
}