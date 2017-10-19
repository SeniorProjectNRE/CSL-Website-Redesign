using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.ViewModels
{
    public class GrantNumberModel
    {
        [StringLength(50)]
        public string GrantID { get; set; }
    }
}