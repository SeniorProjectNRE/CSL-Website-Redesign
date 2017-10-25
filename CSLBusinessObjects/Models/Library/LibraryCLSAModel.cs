using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryCLSAModel
    {
        [StringLength(50)]
        public string CLSA { get; set; }
    }
}