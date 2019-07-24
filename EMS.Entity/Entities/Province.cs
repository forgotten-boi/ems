using EMS.Entity.BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entity.Entities
{
    public class Province : BaseEntity<int>
    {
        public Province()
        {
            this.Districts = new HashSet<District>();
        }
        public string ProvinceNo { get; set; }
        public string ProvinceName { get; set; }
        //[NotMapped]
        public virtual ICollection<District> Districts { get; set; }
    }
}
