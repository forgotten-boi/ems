using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.DtoModel
{
    public class ExhibitorDto
    {
        [Key]
        public int ExhibitorId { get; set; }
        [Required]
        [Display(Name = "नेपालीमा नाम")]
        public string NepaliName { get; set; }
        [Required]
        [Display(Name = "अंग्रेजीमा नाम")]
        public string EnglishName { get; set; }
        [Required]
        [Display(Name = "जिल्ला")]
        public string District { get; set; }
        [Required]
        [Display(Name = "न.पा./गा.वि.स.")]
        public string Municipality { get; set; }
        [Required]
        [Display(Name = "वडा.न.")]
        public int wada { get; set; }
        [Required]
        [Display(Name = "टोल")]
        public string Tol { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "सुरुको मिति")]
        public DateTime PermissionDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "अन्तिम मिति")]
        public DateTime LastDate { get; set; }

        [Required]
        [Display(Name = "चलचित्रघरको प्रबिधि")]
        public string DisplayTech { get; set; } // 
        [Required]
        [Display(Name = "चलचित्रघरको किसिम")]
        public string HallType { get; set; } // चलचित्र घरको किसिम
        [Required]
        [Display(Name = "श्रेणी")]
        public string HallCategory { get; set; } // श्रेणी 
        [Required]
        [Display(Name = "कुल सिट क्षमता")]
        public string HallCapacity { get; set; } // कुल सिट क्षमता
        [Display(Name = "चलचित्र घरको किसिम")]
        public string ProjectorName { get; set; } // चलचित्र घरको किसिम

        [Display(Name = "इक्यूप्मेन्टको विवरण")]
        public string TaxationReliefDetails { get; set; } //

        [Required]
        [Display(Name = "प्रोपराइटरको नाम")]
        public string Proprietor { get; set; }
        [Required]
        [Display(Name = "इमेल")]
        public string ProprietorEmail { get; set; }
        [Required]
        [Display(Name = "मोबाइल न.")]
        public string ProprietorPhone { get; set; }
        [Display(Name = "फर्मको नाम")]
        public string FirmName { get; set; }

        #region DocumentSection
        [Display(Name = "चलचित्र घर निर्माण इजाजतपत्र")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile HallPermissionDoc { get; set; }
        [Display(Name = "कम्पनी दर्ताको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile CompanyRegDoc { get; set; }
        [Display(Name = "जाँच समितिको सिफारिस")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile CheckcommitteeDoc { get; set; }
        [Display(Name = "प्रदर्शन इजाजतपत्र")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile ExhibPermissionDoc { get; set; }
        [Display(Name = "कर चुक्ताको प्रमाण पत्र")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile IncomeTaxDoc { get; set; }
        [Display(Name = "गाँउ/नगर/उपनगर/माहानगर पालिकाको हकमा लाग्ने राजश्व दस्तुर")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile LocalBodyDoc { get; set; }
        [Display(Name = "दरखास्त फारमको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile RegDoc { get; set; }
        #endregion

    }
}
