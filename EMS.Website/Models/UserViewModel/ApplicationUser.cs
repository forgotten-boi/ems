﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entity.DtoModel;
using EMS.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace EMS.Website.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayPicture { get; set; }
        public string JobPost { get; set; }

    }
}
