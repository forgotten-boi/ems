using EMS.Entity.BaseEntity;
using System;
using System.Text;

namespace EMS.Entity.Entities
{
    public class ProducerDetail : BaseEntity<int>
    {
        public DateTime ReleaseDate { get; set; }
        public string MovieName { get; set; }
        public string ArtistsInMovies { get; set; }
        //public virtual ICollection<ArtistInfo> ArtistList { get; set; }
    }
}
