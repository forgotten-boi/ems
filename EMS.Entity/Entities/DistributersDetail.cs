using EMS.Entity.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EMS.Entity.Entities
{
    public class DistributersDetail : BaseEntity<int>
    {
        //public DateTime ReleaseDate { get; set; }
        //public string MovieName { get; set; }
        public string ArtistsInMovies { get; set; }

        //public virtual ICollection<ArtistInfo> ArtistList { get; set; }
        [Required]
        public string NepaliName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Municipality { get; set; }
        public int wada { get; set; }
        public string Tol { get; set; }
        [Required]
        public string Locality { get; set; } // बितरण गर्ने चलचित्र
        [Required]
        public DateTime PermissionDate { get; set; }
        [Required]
        public DateTime LastDate { get; set; }
        [Required]
        public string Proprietor { get; set; }
        public string ProprietorEmail { get; set; }
        public string ProprietorPhone { get; set; }

        #region DocumentSection
        public string CompanyRegDoc { get; set; }
        public string IncomeTaxDoc { get; set; }
        public string DistributionRightDoc { get; set; }
        public string RegDoc { get; set; }

        #endregion
    }
}
