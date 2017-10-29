using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.ViewModels
{
    public class SLAAViewModel
    {
        public List<SLAAModel> SLAAGetAllFromTableList { get; set; }
        public List<SLAAAgencyModel> SLAAAgencyList { get; set; }
        public List<SLAAYearModel> SLAAYearList { get; set; }
        public List<string> GetAgencyListValues { get; set; }
        public List<string> GetYearListValues { get; set; }
        public string SelectedAgency { get; set; }
        public string SelectedYear { get; set; }
    }
}
