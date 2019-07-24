using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace EMS.Entity.DtoModel
{
    public class MovieDto
    {
        [Key]
        public int MovieId { get; set; }
        #region MovieName
        [Required]
        [Display(Name = " चलचित्रको नाम : देवनागरीमा")]
        public string NepaliName { get; set; }
        [Required]
        [Display(Name = "अंग्रेजीमा")]
        public string EnglishName { get; set; }
        #endregion


        [Required]
        [Display(Name = "इजाजपत्र प्राप्त कम्पनी/उद्योग/फर्मको नाम")]
        public string BannerCompany { get; set; }

        #region Director Info
        [Required]
        [Display(Name = "निर्देशकको नाम (देबनागरिकमा)")]
        public string DirectorName { get; set; }
        [Required]
        [Display(Name = "निर्देशकको नाम (अंग्रेजीमा)")]
        public string DirectorEngName { get; set; }
        [Display(Name = "सह-निर्देशक")]
        public string CoDirector { get; set; }
        [Display(Name = "कथाकार")]
        public string Narrator { get; set; }
        [Display(Name = "पटकथाकार")]
        public string CoNarrator { get; set; }
        [Display(Name = "सम्पादक")]
        public string Sampadak { get; set; }
        [Display(Name = "छायाँकार")]
        public string Chhayakar { get; set; }
        [Display(Name = "संगीतकार")]
        public string Musician { get; set; }
        [Display(Name = "ध्वनी नियन्त्रक")]
        public string SoundController { get; set; }
        [Display(Name = "व्दन्द निर्देशक")]
        public string ActionDirector { get; set; }
        [Display(Name = "नृत्य निर्देशक")]
        public string DanceDirector { get; set; }
        [Display(Name = "कला/भेषभुषा")]
        public string KalaCostume { get; set; }
        [Display(Name = "गीतकार")]
        public string Singer { get; set; }
        [Display(Name = "पाश्व संगीतकार")]
        public string CoMusician { get; set; }
        [Display(Name = "मुख्य कलाकारको नाम (देबनागरिकमा)")]
        public string ArtistNameEng { get; set; } //Comma separated AutoCompleteList
        [Display(Name = "मुख्य कलाकारको नाम (अंग्रेजीमा)")]
        public string ArtistNameNep { get; set; }

        #region ProducerName

        [Display(Name = "निर्माताको नाम")]
        public string ProducerName { get; set; }
        [EmailAddress]
        [Display(Name = "निर्माताको :इमेल")]
        public string ProducerEmail { get; set; }
        [Display(Name = "मोबाइल नम्बर ")]
        [Phone]
        public string ProducerPhone { get; set; }
        #endregion

        [Display(Name = "सह-निर्माताको नाम")]
        public string CoProducerName { get; set; }
        [Display(Name = "भाषा")]
        public string Language { get; set; }
        [Display(Name = "प्रविधि")]
        public string Tech { get; set; }
        [Display(Name = "क्यामराको किसिम")]
        public string CamaraType { get; set; }
        [Display(Name = "चलचित्रको किसिम")]
        public string MovCategory { get; set; }
        [Display(Name = "निर्माण सम्पन्न कुल लागत रु")]
        public string Budget { get; set; }
        [Display(Name = "चलचित्रको समय/ लम्बाई")]
        public string MovieLength { get; set; }
        [Display(Name = "इक्यूप्मेन्टको विवरण")]
        public string InstrumentDesc { get; set; }
        [Display(Name = "चलचित्र निर्माण सम्पन्न भएको हो/होइन?")]
        public bool IsCompleted { get; set; }
        [Display(Name = "चलचित्र जांचपास : भएको")]
        public bool IsChecked { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "सिफारिस मिति")]
        public DateTime? CheckedDate { get; set; }
        [Display(Name = "चलचित्र प्रदर्शन : भएको")]
        public bool IsReleased { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "सिफारिस मिति")]
        public DateTime? ReleasedDate { get; set; }

        [Display(Name = "विदेशमा प्रदर्शनको लागि सिफारिस भएको")]
        public bool ForeignRelease { get; set; }
        [Display(Name = "च्यारिटीको लागि सिफारिस गरिएको")]
        public bool IsCharitable { get; set; }
        #endregion

        #region Nirman Permission

        [DataType(DataType.Date)]
        [Display(Name = "निर्माण इजाजत पत्र लिएको मिति")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "निर्माण इजाजत पत्र समाप्त")]
        public DateTime EndDate { get; set; }
        #endregion

        #region PostProduction
        [Display(Name = "नाम")]
        public string PostName { get; set; }
        [Display(Name = "ठेगाना")]
        public string PostAddress { get; set; }
        [Display(Name = "पोस्ट प्रोडक्सन सिफारिस")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile PostProdDoc { get; set; }
        [Display(Name = "चलचित्रको पोस्टर")]
        [FileExtensionHelper(MaxSize:0.5)]
        public IFormFile MovieBannerDoc { get; set; }
        #endregion


    
        #region DocumentSection
        [Display(Name = "क) चलचित्र निर्माण इजाजतपत्रको सक्कल प्रतिलिपि :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile PermissionDoc { get; set; }
        [Display(Name = "ख) कथासारको प्रतिलिपि :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile ScriptDoc { get; set; }
        [Display(Name = "ग) गीतको प्रतिलिपि :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile SongDoc { get; set; }
        [Display(Name = "घ) मुख्य कलाकारहरुसंगको सम्झैता :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile ContractDoc { get; set; }
        [Display(Name = "ङ) जाचंपासको सक्कल प्रतिलिपि :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile SensorDoc { get; set; }
        [Display(Name = "च) दरखास्त फारमको प्रतिलिपि  :")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile RegDoc { get; set; }

        #endregion

        public bool? IsApproved { get; set; }

        public string GetApproval
        {
            get {
                    switch (IsApproved)
                    {
                        case true:
                            return "Approved";
                        case false:
                            return "Rejected";
                        case null:
                            return "Pending";
                        default:
                            return "pending";
                    }
            }
           
        }


    }
}
