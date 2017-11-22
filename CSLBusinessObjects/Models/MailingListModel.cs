using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.Models
{
    public class MailingListModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }

        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Display(Name = "Organization Type")]
        public string OrganizationType { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        public bool IsCSLNewsandEvents { get; set; }

        public bool IsBTBLUpdates { get; set; }

        public bool IsCaliforniaStatePublications { get; set; }

        public bool IsCRBLunchwithaSideofResearch { get; set; }

        public bool IsCRBStudiesintheNews { get; set; }

        public bool IsAll { get; set; }

        public bool IsFormat { get; set; }
    }
}
