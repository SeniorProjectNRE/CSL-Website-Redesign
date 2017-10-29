using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.Models
{
    [Serializable]
    public class SLAAModel
    {
        public int ReportID { get; set; }

        public string Year { get; set; }

        [StringLength(100)]
        public string AgencyName { get; set; }

        [StringLength(20)]
        public string AgencyCode { get; set; }

        public int? CAP { get; set; }

        public int? Voided { get; set; }
    }
}
