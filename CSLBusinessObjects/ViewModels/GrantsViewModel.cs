using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.ViewModels
{
    public class GrantsViewModel
    {
        public List<GrantNumberModel> GrantNumberList { get; set; }
        public List<GrantYearModel> GrantYearList { get; set; }
        public List<GrantLibraryModel> GrantLibraryList { get; set; }
        public List<GrantProjectModel> GrantProjectList { get; set; }
        public List<GrantAwardModel> GrantAwardList { get; set; }
        public List<GrantCategoryModel> GrantCategoryList { get; set; }
        public List<GrantsModel> GrantGetAllList { get; set; }
        public List<string> GetListValues { get; set; }
    }
}
