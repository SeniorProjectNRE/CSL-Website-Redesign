using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLDataAccessLayer
{
    public interface IDataAccess
    {
        #region Grants
        void GetGrantNumber(string grantNum, string year, string library, string project, string category, int award);
        void GetYear(string grantNum, string year, string library, string project, string category, int award);
        void GetLibrary(string grantNum, string year, string library, string project, string category, int award);
        void GetProject(string grantNum, string year, string library, string project, string category, int award);
        void GetAward(string grantNum, string year, string library, string project, string category, int award);
        void GetCategory(string grantNum, string year, string library, string project, string category, int award);
        GrantsModel GetAllGrants(string grantNum, string year, string library, string project, string category, int award);
        #endregion

    }
}
