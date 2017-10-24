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

        //public List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award)
        //{
        //    return _dataAccess.GetAllGrants(grantNum, year, library, project, award);
        //}

        public List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            DataTable myData = _dataAccess.GetAllGrants(grantNum, year, library, project, award);
            List<GrantsModel> res = new List<GrantsModel>();
            GrantsModel grantsModel;

            try
            {
                foreach(DataRow row in myData.Rows)
                {
                    grantsModel = new GrantsModel()
                    {
                        Award = Convert.ToInt32(row["Award"]),
                        Library = row["Library"].ToString(),
                        GrantID = row["GrantID"].ToString(),
                        Project = row["Project"].ToString(),
                        Year = row["Year"].ToString()
                    };
                    res.Add(grantsModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
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

        public List<string> AwardStrings()
        {
            List<string> res = new List<string>();
            string all = "All";
            string a = "$0 - $10,000";
            string b = "$10,000 - $50,000";
            string c = "$50,000 - $100,000";
            string d = "$100,000 - $500,000";
            string e = "$500,000 - $1,000,000";
            string f = "> $1,000,000";
            res.Add(all);
            res.Add(a);
            res.Add(b);
            res.Add(c);
            res.Add(d);
            res.Add(e);
            res.Add(f);
            return res;
        }

        public int GetAwardCategoryFromString(string award)
        {
            int res = 0;
            switch (award)
            {
                case "All":
                    res = 0;
                    break;
                case "$0 - $10,000":
                    res = 1;
                    break;
                case "$10,000 - $50,000":
                    res = 2;
                    break;
                case "$50,000 - $100,000":
                    res = 3;
                    break;
                case "$100,000 - $500,000":
                    res = 4;
                    break;
                case "$500,000 - $1,000,000":
                    res = 5;
                    break;
                case "> $1,000,000":
                    res = 6;
                    break;
            }
            return res;
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
