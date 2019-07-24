using EMS.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entity.Entities
{
    public class MovieInfo : BaseEntity<int>
    {
        public MovieInfo()
        {
            this.ArtistInfos = new HashSet<ArtistInfo>();
        }
        [Required]
        public string MovieName { get; set; }
        [NotMapped]
        public virtual ICollection<ArtistInfo> ArtistInfos{ get; set; }
        //[ForeignKey(nameof(ProducerId))]
        //public ProducerDetail ProducerInfo { get; set; }
        //public int ProducerId { get; set; }
        #region MovieName
        [Required]
        public string NepaliName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        #endregion

        #region ProducerName
       
        [EmailAddress]
        [Display(Name = "निर्माताको :इमेल")]
        public string ProducerEmail { get; set; }
        [Display(Name = "मोबाइल नम्बर ")]
        [Phone]
        public string ProducerPhone { get; set; }
        #endregion
        [Required]
        public string BannerCompany { get; set; }

        #region Director Info
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string DirectorEngName { get; set; }
        public string CoDirector { get; set; }
        public string Narrator { get; set; }
        public string CoNarrator { get; set; }
        public string Sampadak { get; set; }
        public string Chhayakar { get; set; }
        public string Musician { get; set; }
        public string SoundController { get; set; }
        public string ActionDirector { get; set; }

        public string DanceDirector { get; set; }

        public string KalaCostume { get; set; }
        public string Singer { get; set; }
        public string CoMusician { get; set; }
        public string ArtistNameEng { get; set; } //Comma separated AutoCompleteList
        public string ArtistNameNep { get; set; }

        public string ProducerName { get; set; }
        public string CoProducerName { get; set; }
        public string Language { get; set; }
        public string Tech { get; set; }
        public string CamaraType { get; set; }
        public string MovCategory{ get; set; }
        public string Budget { get; set; }
        public string MovieLength { get; set; }
        public string InstrumentDesc { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsChecked { get; set; }
        public DateTime? CheckedDate { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleasedDate { get; set; }

        public bool ForeignRelease { get; set; }
        public bool IsCharitable { get; set; }
        #endregion

        #region Nirman Permission

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion

        #region PostProduction
        public string PostName { get; set; }
        public string PostAddress { get; set; }
        public string PostProdDoc { get; set; }
        public string MovieBanner { get; set; }
        #endregion



        #region DocumentSection
        public string PermissionDoc { get; set; }
        public string ScriptDoc { get; set; }
        public string SongDoc { get; set; }
        public string ContractDoc { get; set; }
        public string SensorDoc { get; set; }
        public string RegDoc { get; set; }

        #endregion

        public bool? IsApproved { get; set; }
        public virtual ApprovalInfo ApprovalInfo { get; set; }
    }

   
}
