using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface IGrantsService
    {
        List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award);
        List<GrantAwardModel> GetAllAwards(string grantNum, string year, string library, string project, int award);
        List<GrantProjectModel> GetAllProjects(string grantNum, string year, string library, string project, int award);
        List<GrantLibraryModel> GetAllLibraries(string grantNum, string year, string library, string project, int award);
        List<GrantYearModel> GetAllYears(string grantNum, string year, string library, string project, int award);
        List<GrantNumberModel> GetAllGrantIDs(string grantNum, string year, string library, string project, int award);
        List<string> GetNumListValues(List<GrantNumberModel> model);
        List<int> GetAwardListValues(List<GrantAwardModel> model);
        List<string> GetProjectListValues(List<GrantProjectModel> model);
        List<string> GetLibrariesListValues(List<GrantLibraryModel> model);
        List<string> GetYearListValues(List<GrantYearModel> model);
        List<String> AwardStrings();
        int GetAwardCategoryFromString(string v);
    }
}
