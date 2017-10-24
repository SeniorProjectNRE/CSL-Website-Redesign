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
    public class GrantsModel
    {
        [StringLength(50)]
        public string GrantID { get; set; }

        [StringLength(100)]
        public string Library { get; set; }

        [StringLength(200)]
        public string Project { get; set; }

        public string Award { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        [StringLength(50)]
        public string FileID { get; set; }

        public bool? Literacy { get; set; }

        public bool? ContinuingEducation { get; set; }

        public bool? Technology { get; set; }

        public bool? Preservation { get; set; }

        public bool? CommunityConnections { get; set; }

        public bool? LibraryAccess { get; set; }

        public bool? EarlyLearning { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedOn { get; set; }

        public byte? Voided { get; set; }
    }
}
