using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
    public class MiscExpenses : BaseEntity<int>
    {
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("TravelExpenses")]
        public int TraveExpID { get; set; }
        public virtual TravelExpenses TravelExpenses { get; set; }
    }
}