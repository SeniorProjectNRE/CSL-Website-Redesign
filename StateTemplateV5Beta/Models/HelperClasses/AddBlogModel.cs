using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StateTemplateV5Beta.Models.HelperClasses
{
    public class AddBlogModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public Nullable<short> Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public Nullable<short> Description { get; set; }

    }
}