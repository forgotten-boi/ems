using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
    public class TravelExpenses : BaseEntity<int>
    {

        [ForeignKey("TravelInfo")]
        public int TravelID { get; set; }
        public virtual TravelInfo TravelInfo { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public double Expenses { get; set; }
    }
}