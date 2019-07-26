using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
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
}