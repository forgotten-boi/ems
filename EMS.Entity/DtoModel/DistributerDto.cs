using Microsoft.AspNetCore.Http;
using EMS.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EMS.Entity.DtoModel
{
    public class DistributerDto
    {
        [Key]
        public int DistributerId { get; set; }
        //[Required]
        //public string MovieName { get; set; }
        [Display(Name = "नेपालीमा नाम")]
        [Required]
        public string NepaliName { get; set; }
        [Display(Name = "अंग्रेजीमा नाम")]
        [Required]
        public string EnglishName { get; set; }
        [Display(Name = "जिल्ला")]
        [Required]
        public string District { get; set; }
        [Display(Name = "न.पा./गा.वि.स.")]
        [Required]
        public string Municipality { get; set; }
        [Display(Name = "वडा.न.")]
        public int wada { get; set; }
        [Display(Name = "टोल")]
        public string Tol { get; set; }
        [Display(Name = "बितरण गर्ने चलचित्र")]
        [Required]
        public string Locality { get; set; }
        [Display(Name = "सुरुको मिति")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PermissionDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "अन्तिम मिति")]
        public DateTime LastDate { get; set; }
        [Display(Name = "प्रोपराइटरको नाम")]
        [Required]
        public string Proprietor { get; set; }
        [Display(Name = "इमेल")]
        public string ProprietorEmail { get; set; }
        [Display(Name = "मोबाइल न")]
        public string ProprietorPhone { get; set; }

        #region DocumentSection
        [Display(Name = "कम्पनी दर्ताको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile CompanyRegDoc { get; set; }
        [Display(Name = "आयकर  चुक्ताको काग़ज़ातहरू")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile IncomeTaxDoc { get; set; }
        [Display(Name = "वितरण इजाज़तपत्रको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile DistributionRightDoc { get; set; }
        [Display(Name = "दरखास्त फारमको प्रतिलिपि")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile RegDoc { get; set; }



        #endregion

    }
}
