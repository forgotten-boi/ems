using EMS.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entity.Entities
{
    public class BannerInfo : BaseEntity<int>
    {
        [Required]
        public string NepaliName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string RegisterationNo { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        public string ShareHolderAddress { get; set; }
        [Required]
        public string ShareHolderName { get; set; }
        public string ShareHolderPhone { get; set; }
        public string FormRegDoc { get; set; }
        public string TaxRegDoc { get; set; }


    }
}
