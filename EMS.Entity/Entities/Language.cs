using EMS.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity.Entities
{
    public class Language : BaseEntity<int>
    {
        public string NepName { get; set; }
        public string EngName { get; set; }
    }
}
