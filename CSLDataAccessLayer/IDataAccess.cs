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
        void GetGrantNumber(string grantNum, string year, string library, string project, int award);
        void GetYear(string grantNum, string year, string library, string project, int award);
        void GetLibrary(string grantNum, string year, string library, string project, int award);
        void GetProject(string grantNum, string year, string library, string project, int award);
        void GetAward(string grantNum, string year, string library, string project, int award);
        //void GetCategory(string grantNum, string year, string library, string project, string category, int award);
        GrantsViewModel GetAllGrants(string grantNum, string year, string library, string project, int award);
        #endregion

    }
}
