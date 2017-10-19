using CSLDataAccessLayer;
using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSLBusinessObjects.ViewModels;
using CSLBusinessLayer.Interface;

namespace CSLBusinessLayer.Concrete
{
    public class GrantsService : IGrantsService
    {
        private IDataAccess _dataAccess;


        public GrantsService(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public GrantsViewModel GetAllAwards(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetAward(grantNum, year, library, project, award);
        }

        public GrantsViewModel GetAllGrantIDs(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetGrantNumber(grantNum, year, library, project, award);
        }

        public GrantsViewModel GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetAllGrants(grantNum, year, library, project, award);
        }

        public GrantsViewModel GetAllLibraries(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetLibrary(grantNum, year, library, project, award);
        }

        public GrantsViewModel GetAllProjects(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetProject(grantNum, year, library, project, award);
        }

        public GrantsViewModel GetAllYears(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetYear(grantNum, year, library, project, award);
        }
    }
}
