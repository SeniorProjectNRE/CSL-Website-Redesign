using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLDataAccessLayer
{
    public interface IDataAccess
    {
        #region Grants
        List<GrantNumberModel> GetGrantNumber(string grantNum, string year, string library, string project, int award);
        List<GrantYearModel> GetYear(string grantNum, string year, string library, string project, int award);
        List<GrantLibraryModel> GetLibrary(string grantNum, string year, string library, string project, int award);
        List<GrantProjectModel> GetProject(string grantNum, string year, string library, string project, int award);
        List<GrantAwardModel> GetAward(string grantNum, string year, string library, string project, int award);
        //void GetCategory(string grantNum, string year, string library, string project, string category, int award);
        List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award);
        #endregion

    }
}
