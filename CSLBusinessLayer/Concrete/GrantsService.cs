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

        public List<GrantAwardModel> GetAllAwards(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetAward(grantNum, year, library, project, award);
        }

        public List<GrantNumberModel> GetAllGrantIDs(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetGrantNumber(grantNum, year, library, project, award);
        }

        public List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetAllGrants(grantNum, year, library, project, award);
        }

        public List<GrantLibraryModel> GetAllLibraries(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetLibrary(grantNum, year, library, project, award);
        }

        public List<GrantProjectModel> GetAllProjects(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetProject(grantNum, year, library, project, award);
        }

        public List<GrantYearModel> GetAllYears(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetYear(grantNum, year, library, project, award);
        }

        public List<string> GetListValues(List<GrantNumberModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.GrantID;
                res.Add(value);
            }
            return res;
        }
    }
}
