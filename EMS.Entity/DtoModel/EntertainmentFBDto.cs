using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.DtoModel
{
    public class EntertainmentFBDto
    {
        [Key]
        public int EntertainmentFBId { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}