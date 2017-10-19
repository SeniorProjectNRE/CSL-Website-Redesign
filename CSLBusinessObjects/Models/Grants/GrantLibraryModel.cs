using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class GrantLibraryModel
    {
        [StringLength(100)]
        public string Library { get; set; }
    }
}