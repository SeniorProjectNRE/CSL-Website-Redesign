using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using StateTemplateV5Beta.Models;

namespace StateTemplateV5Beta.Models.HelperClasses
{
    public class HomeViewModel
    {

        public IEnumerable<Blog> BlogList { get; set; }

    }
}