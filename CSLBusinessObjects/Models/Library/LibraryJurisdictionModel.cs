using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryJurisdictionModel
    {
        [StringLength(100)]
        public string Jurisdiction { get; set; }
    }
}