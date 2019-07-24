using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entity.Entities
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}
