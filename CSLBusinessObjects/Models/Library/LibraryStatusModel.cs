using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryStatusModel
    {
        [StringLength(100)]
        public string Status { get; set; }
    }
}