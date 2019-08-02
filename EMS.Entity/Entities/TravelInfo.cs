using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
    public class TravelInfo : BaseEntity<int>
    {


        [Required]
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }

       
        public string Destination { get; set; }
        public string Purpose { get; set; }
        public string RecieptDoc { get; set; }

        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string Department { get; set; }
        public string Currency { get; set; }
        public double TotalExpenses { get; set; }

        private DateTime UpdateDate;
        public DateTime Date
        {
            get { return UpdateDate; }
            set { UpdateDate = value==default? DateTime.Now: value; }
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
        public virtual ApprovalInfo ApprovalInfo { get; set; }

        public virtual ICollection<TravelExpenses> TravelExpenses { get; set; }

    }
}