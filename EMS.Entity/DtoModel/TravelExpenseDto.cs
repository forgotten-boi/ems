using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.DtoModel
{
    public class TravelExpenseDto
    {
        [Key]
        public int TravelExpId { get; set; }
        public int TravelID { get; set; }

        public string Details { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public double Expenses { get; set; }

        public ICollection<MiscExpenseDto> MiscExpensesDtos { get; set; }
    }
}