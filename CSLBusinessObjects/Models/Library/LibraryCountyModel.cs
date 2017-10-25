using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryCountyModel
    {
        [StringLength(50)]
        public string County { get; set; }
    }
}