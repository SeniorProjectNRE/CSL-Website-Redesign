using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryCityModel
    {
        [StringLength(50)]
        public string City { get; set; }
    }
}