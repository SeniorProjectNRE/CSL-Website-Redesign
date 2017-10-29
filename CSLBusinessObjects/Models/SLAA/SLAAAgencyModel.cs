using System.ComponentModel.DataAnnotations;

namespace CSLBusinessObjects.Models
{
    public class SLAAAgencyModel
    {
        [StringLength(200)]
        public string AgencyCode{ get; set; }
    }
}