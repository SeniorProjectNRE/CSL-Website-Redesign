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
            DataTable myData = _dataAccess.GetAward(grantNum, year, library, project, award);
            List<GrantAwardModel> res = new List<GrantAwardModel>();
            GrantAwardModel awardModel;

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    awardModel = new GrantAwardModel()
                    {
                        Award = Convert.ToInt32(row["Award"]),
                    };
                    res.Add(awardModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<GrantNumberModel> GetAllGrantIDs(string grantNum, string year, string library, string project, int award)
        {
            DataTable myData = _dataAccess.GetGrantNumber(grantNum, year, library, project, award);
            List<GrantNumberModel> res = new List<GrantNumberModel>();
            GrantNumberModel numberModel;
            GrantNumberModel allModel = new GrantNumberModel() { GrantID = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    numberModel = new GrantNumberModel()
                    {
                        GrantID = row["GrantID"].ToString(),
                    };
                    res.Add(numberModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
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
                        Award = Convert.ToInt32(row["Award"]).ToString("c0"),
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
            DataTable myData = _dataAccess.GetLibrary(grantNum, year, library, project, award);
            List<GrantLibraryModel> res = new List<GrantLibraryModel>();
            GrantLibraryModel libraryModel;
            GrantLibraryModel allModel = new GrantLibraryModel() { Library = "All"};
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    libraryModel = new GrantLibraryModel()
                    {
                        Library = row["Library"].ToString(),
                    };
                    res.Add(libraryModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<GrantProjectModel> GetAllProjects(string grantNum, string year, string library, string project, int award)
        {
            DataTable myData = _dataAccess.GetProject(grantNum, year, library, project, award);
            List<GrantProjectModel> res = new List<GrantProjectModel>();
            GrantProjectModel projectModel;
            GrantProjectModel allModel = new GrantProjectModel() { Project = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    projectModel = new GrantProjectModel()
                    {
                        Project = row["Project"].ToString(),
                    };
                    res.Add(projectModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<GrantYearModel> GetAllYears(string grantNum, string year, string library, string project, int award)
        {
            DataTable myData = _dataAccess.GetYear(grantNum, year, library, project, award);
            List<GrantYearModel> res = new List<GrantYearModel>();
            GrantYearModel yearModel;
            GrantYearModel allModel = new GrantYearModel() { Year = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    yearModel = new GrantYearModel()
                    {
                        Year = row["Year"].ToString(),
                    };
                    res.Add(yearModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
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
