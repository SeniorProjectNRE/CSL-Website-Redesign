using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class GrantYearModel
    {
        [StringLength(50)]
        public string Year { get; set; }
    }
}