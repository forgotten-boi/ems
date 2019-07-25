using EMS.Entity.DtoModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Website.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Delete User")]
        public bool IsDeleted { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Display Picture")]
        [FileExtensionHelper(MaxSize: 2)]
        public IFormFile DisplayPicture { get; set; }

        public string TeamLeadId { get; set; }
        public virtual ApplicationUser TeamLead { get; set; }
        public virtual ApplicationUser Employee { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }
       
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Job Post")]
        public string JobPost { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public string ImagePath { get; set; }
        [Display(Name = "Display Picture")]
        public IFormFile DisplayPicture { get; set; }

        public string TeamLeadId { get; set; }
        public virtual ApplicationUser TeamLead { get; set; }
    }
}
