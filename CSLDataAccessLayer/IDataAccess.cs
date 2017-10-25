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
        DataTable GetGrantNumber(string grantNum, string year, string library, string project, int award);
        DataTable GetYear(string grantNum, string year, string library, string project, int award);
        DataTable GetLibrary(string grantNum, string year, string library, string project, int award);
        DataTable GetProject(string grantNum, string year, string library, string project, int award);
        DataTable GetAward(string grantNum, string year, string library, string project, int award);
        DataTable GetAllGrants(string grantNum, string year, string library, string project, int award);
        //DataTable GetCategory(string grantNum, string year, string library, string project, string category, int award);
        #endregion

        #region Library
        DataTable GetAssembly(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetCity(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetCLSA(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetCongress(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetCounty(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetJurisdiction(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetLibrary(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetSenate(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetCode(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetStatus(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetZip(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        DataTable GetAllBroadband(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        #endregion


    }
}
