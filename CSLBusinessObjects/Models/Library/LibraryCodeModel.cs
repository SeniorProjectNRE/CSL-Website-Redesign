using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryCodeModel
    {
        [StringLength(50)]
        public string StatusCode { get; set; }
    }
}