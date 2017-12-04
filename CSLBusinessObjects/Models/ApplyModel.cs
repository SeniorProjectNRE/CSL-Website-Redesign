using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.Models
{
    public class ApplyModel
    {
        [Display(Name = "I am... ")]
        [Required(ErrorMessage = "Please select your position")]
        public List<string> Jobs { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        public string InstructorEmail { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string InstructorDepartment { get; set; }

        [Display(Name = "Home Address")]
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter your city.")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Please enter your zip code.")]
        public string ZipCode { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter your email address.")]
        public string Email { get; set; }

        [Display(Name = "Home Phone")]
        [Required(ErrorMessage = "Please enter your home phone number.")]
        public string HomePhone { get; set; }

        [Display(Name = "Agency/Affiliation")]
        [Required(ErrorMessage = "Please enter your agency.")]
        public List<string> Agency { get; set; }

        [Display(Name = "Work Address")]
        public string WorkAddress { get; set; }

        [Display(Name = "Work City")]
        public string WorkCity { get; set; }

        [Display(Name = "Work Zip Code")]
        public string WorkZipCode { get; set; }

        [Display(Name = "Work Email Address")]
        public string WorkEmail { get; set; }

        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        public bool IAgree { get; set; }
    }
}
