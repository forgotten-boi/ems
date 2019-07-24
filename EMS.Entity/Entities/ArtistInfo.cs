using EMS.Entity.BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entity.Entities
{
    public class ArtistInfo : BaseEntity<int>
    {
        public ArtistInfo()
        {
            this.MovieInfos = new HashSet<MovieInfo>();                    
        }
        [Required]
        public string FullName { get; set; }
        [NotMapped]
        public virtual ICollection<MovieInfo> MovieInfos { get; set; }
    }
}
