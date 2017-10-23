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
        public List<string> GetNumListValues { get; set; }
        public List<int> GetAwardListValues { get; set; }
        public List<string> GetProjectListValues { get; set; }
        public List<string> GetLibrariesListValues { get; set; }
        public List<string> GetYearListValues { get; set; }
        public string SelectedGrantID { get; set; }
        public int SelectedAward { get; set; }
        public string SelectedProject { get; set; }
        public string SelectedLibrary { get; set; }
        public string SelectedYear { get; set; }
    }
}
