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

        public List<int> GetAwardListValues(List<GrantAwardModel> model)
        {
            List<int> res = new List<int>();
            foreach (var item in model)
            {
                int value = (int)item.Award;
                res.Add(value);
            }
            return res;
        }

        public List<string> GetLibrariesListValues(List<GrantLibraryModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Library;
                res.Add(value);
            }
            return res;
        }

        public List<string> GetNumListValues(List<GrantNumberModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.GrantID;
                res.Add(value);
            }
            return res;
        }

        public List<string> GetProjectListValues(List<GrantProjectModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Project;
                res.Add(value);
            }
            return res;
        }

        public List<string> GetYearListValues(List<GrantYearModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Year;
                res.Add(value);
            }
            return res;
        }
    }
}
