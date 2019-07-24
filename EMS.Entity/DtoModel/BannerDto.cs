using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.DtoModel
{
    public class BannerDto
    {
        [Key]
        public int BannerId { get; set; }
        [Required]
        [Display(Name = "ब्यानरको नाम नेपालीमा")]
        public string NepaliName { get; set; }
        [Required]
        [Display(Name = "ब्यानरको नाम अंग्रेजीमा")]
        public string EnglishName { get; set; }
        [Required]
        [Display(Name = "दर्ता नं.")]
        public string RegisterationNo { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "मिति (वि. स.)")]
        public DateTime RegDate { get; set; }
        [Display(Name = "ठेगाना")]
        public string ShareHolderAddress { get; set; }
        [Display(Name = "शेयरधनीको नाम")]
        [Required]
        public string ShareHolderName { get; set; }
        [Display(Name = "टेलिफोन नम्बर")]
        public string ShareHolderPhone { get; set; }

        [Display(Name = "उद्योग वा फर्म दर्ता प्रमाणपत्रको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile FormRegDoc { get; set; }
        [Display(Name = "कर प्रयोजनको लागि दर्ता भएको प्रमाणपत्रको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile TaxRegDoc { get; set; }
    }
}
