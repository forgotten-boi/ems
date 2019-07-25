using EMS.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    
        //public virtual ICollection<TravelInfo> TravelInfos { get; set; }
    }

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
        public virtual ApprovalInfo ApprovalInfo { get; set; }

        public virtual ICollection<TravelExpenses> TravelExpenses { get; set; }

    }

    public class ApprovalInfo : BaseEntity<int>
    {
        [ForeignKey("TravelInfo")]
        public int TravelID { get; set; }
        public virtual TravelInfo TravelInfo { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string Comment { get; set; }
        public DateTime ApprovedDate { get; set; }

        public double TotalExpenses { get; set; }
    }

    public class MiscExpenses : BaseEntity<int>
    {
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
    public class EntertainmentFB : BaseEntity<int>
    {
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }


    public class TravelExpenses : BaseEntity<int>
    {

        [ForeignKey("TravelInfo")]
        public int TravelID { get; set; }
        public virtual TravelInfo TravelInfo { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public double Expenses { get; set; }
    }

    public class MstExpenses : BaseEntity<int>
    {
        public string Comment { get; set; }
        public int Order { get; set; }
    }

}
