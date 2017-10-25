using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryLibraryModel
    {
        [StringLength(100)]
        public string LibraryName { get; set; }
    }
}