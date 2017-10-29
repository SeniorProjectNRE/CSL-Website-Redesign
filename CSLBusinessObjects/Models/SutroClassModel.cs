using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.Models
{
    public class SutroClassModel
    {
        [Display(Name = "Instruction requested by:")]
        public string Instructor { get; set; }

        [Display(Name = "Email:")]
        public string InstructorEmail { get; set; }

        [Display(Name = "Department:")]
        public string InstructorDepartment { get; set; }

        [Display(Name = "Course number and title:")]
        public string CourseNumandTitle { get; set; }

        [Display(Name = "The date, time, and frequency of your class visit (one time, multiple, or all quarter):")]
        [Required(ErrorMessage = "The date, time, and frequency of your class visit is required.")]
        public string Frequency { get; set; }

        [Display(Name = "The approximate number of students in each class:")]
        [Required(ErrorMessage = "The approximate number of students in each class is required.")]
        public string StudentAmount { get; set; }

        [Display(Name = "How long your class session at the Sutro will be (half hour, an hour, etc.):")]
        [Required(ErrorMessage = "The length of your class session is required.")]
        public string ClassTimeLength { get; set; }

        [Display(Name = "Is there an assignment, paper, or project the students will have to complete using Special Collections materials during the quarter? Is group study a requirement?:")]
        [Required(ErrorMessage = "Is there an assignment, paper, or project? Is group study required?")]
        public string DoesAssignmentExist { get; set; }

        [Display(Name = "List of the materials to be used (please allow at least 3-4 days before the date of the scheduled class meeting):")]
        [Required(ErrorMessage = "The list of materials to be used is required.")]
        public string Materials { get; set; }

        [Display(Name = "Are You Hooman?")]
        public bool IsCaptcha { get; set; }

        public string SuccessMessage { get; set; }
    }
}
