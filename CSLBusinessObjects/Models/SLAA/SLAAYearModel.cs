using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.Models
{
    public class SLAAYearModel
    {
        [StringLength(50)]
        public string Year { get; set; }
    }
}