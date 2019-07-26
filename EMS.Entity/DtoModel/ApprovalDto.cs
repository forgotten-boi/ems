using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entity.DtoModel
{
    public class ApprovalDto
    {
        public int ApprovalId { get; set; }

        [ForeignKey("TravelInfo")]
        public int TravelID { get; set; }
 

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime ApprovedDate { get; set; }

        public double TotalExpenses { get; set; }
    }
}