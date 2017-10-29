using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.Models
{
    public class LibraryModel
    {
        [StringLength(50)]
        public string OutletID { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        [StringLength(100)]
        public string Jurisdiction { get; set; }

        [StringLength(100)]
        public string LibraryName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public string Zip { get; set; }

        public int? Zip4 { get; set; }

        [StringLength(50)]
        public string County { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public string AssemblyDistrict { get; set; }

        public string SenateDistrict { get; set; }

        public string CongressionalDistrict { get; set; }

        [StringLength(50)]
        public string CLSA { get; set; }

        [StringLength(50)]
        public string LIBCODE { get; set; }

        [StringLength(50)]
        public string FSCSKEY { get; set; }

        public decimal? AccuracyS { get; set; }

        [StringLength(50)]
        public string AccuracyT { get; set; }

        public int? ID { get; set; }

        public decimal? AREA { get; set; }

        public int? DATA { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(50)]
        public string StatusCode { get; set; }

        [StringLength(300)]
        public string Notes { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public bool? Voided { get; set; }

        public bool? IsLive { get; set; }
    }
}
