using EMS.Entity.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entity.Entities
{
    public class ArtistInMovie : BaseEntity<int>
    {
        public ArtistInMovie()
        {
            this.ArtistInfo = new ArtistInfo();
            this.MovieInfo = new MovieInfo();

        }
        [ForeignKey(nameof(MovieId))]
        public MovieInfo MovieInfo { get; set; }
        public int MovieId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public ArtistInfo ArtistInfo { get; set; }
        public int ArtistId { get; set; }

    }
}
