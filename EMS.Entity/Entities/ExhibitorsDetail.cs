using EMS.Entity.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.Entities
{
    public class ExhibitorsDetail : BaseEntity<int>
    {
        [Required]
        public string NepaliName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Municipality { get; set; }
        [Required]
        public int wada { get; set; }
        [Required]
        public string Tol { get; set; }
        [Required]
        public DateTime PermissionDate { get; set; }
        [Required]
        public DateTime LastDate { get; set; }

        [Required]
        public string DisplayTech { get; set; } // चलचित्रघरको प्रबिधि
        [Required]
        public string HallType { get; set; } // चलचित्र घरको किसिम
        [Required]
        public string HallCategory { get; set; } // श्रेणी 
        [Required]
        public string HallCapacity { get; set; } // कुल सिट क्षमता
        public string ProjectorName { get; set; } // चलचित्र घरको किसिम

        public string TaxationReliefDetails { get; set; } //भन्सार महशुल छुटमा ल्याएको इक्यूप्मेन्टको विवरण

        [Required]
        public string Proprietor { get; set; }
        [Required]
        public string ProprietorEmail { get; set; }
        [Required]
        public string ProprietorPhone { get; set; }

        public string FirmName { get; set; }

        #region DocumentSection
        public string HallPermissionDoc { get; set; }
        public string CompanyRegDoc { get; set; }
        public string CheckcommitteeDoc { get; set; }
        public string ExhibPermissionDoc { get; set; }
        public string IncomeTaxDoc { get; set; }
        public string LocalBodyDoc { get; set; }
        public string RegDoc { get; set; }
        #endregion

    }
}
