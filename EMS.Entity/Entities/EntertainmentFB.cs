using System;
using EMS.Entity.BaseEntity;

namespace EMS.Entity.Entities
{
    public class EntertainmentFB : BaseEntity<int>
    {
        public string Comment { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}