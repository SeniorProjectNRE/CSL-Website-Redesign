using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class GrantProjectModel
    {
        [StringLength(200)]
        public string Project { get; set; }
    }
}