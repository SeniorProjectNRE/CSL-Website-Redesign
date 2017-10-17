using CSLBusinessObjects.ConfigModels;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLDataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        private string _dbConnectionString;

        public DataAccess(DBConnectionConfig config)
        {
            _dbConnectionString = config.ConnectionString;
        }

        public GrantsViewModel GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            GrantsViewModel res = new GrantsViewModel();
            res.GrantAwardList = new List<GrantAwardModel>();
            res.GrantCategoryList = new List<GrantCategoryModel>();
            res.GrantGetAllList = new List<GrantsModel>();
            res.GrantLibraryList = new List<GrantLibraryModel>();
            res.GrantNumberList = new List<GrantNumberModel>();
            res.GrantProjectList = new List<GrantProjectModel>();
            res.GrantYearList = new List<GrantYearModel>();
            GrantAwardModel grantAward;
            GrantCategoryModel grantCategory;
            GrantsModel grantsModel;
            GrantLibraryModel grantLibrary;
            GrantNumberModel grantNumber;
            GrantProjectModel grantProject;
            GrantYearModel grantYear;

            SqlConnection conn = new SqlConnection(_dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspSeeAllGrants]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@grantNum", grantNum);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@library", library);
            cmd.Parameters.AddWithValue("@project", project);
            cmd.Parameters.AddWithValue("@award", award);

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantAward = new GrantAwardModel();
                        grantAward.Award = Convert.ToInt32(reader["Award"]);
                        res.GrantAwardList.Add(grantAward);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        grantsModel = new GrantsModel();
                        grantsModel.Award = Convert.ToInt32(reader["Award"]);
                        grantsModel.Library = reader["Library"].ToString();
                        grantsModel.GrantID = reader["GrantID"].ToString();
                        grantsModel.Project = reader["Project"].ToString();
                        grantsModel.Year = reader["Year"].ToString();
                        res.GrantGetAllList.Add(grantsModel);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        grantLibrary = new GrantLibraryModel();
                        grantLibrary.Library = reader["Library"].ToString();
                        res.GrantLibraryList.Add(grantLibrary);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        grantNumber = new GrantNumberModel();
                        grantNumber.GrantID = reader["GrantID"].ToString();
                        res.GrantNumberList.Add(grantNumber);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        grantProject = new GrantProjectModel();
                        grantProject.Project = reader["Project"].ToString();
                        res.GrantProjectList.Add(grantProject);
                    }
                    reader.NextResult();

                    while (reader.Read())
                    {
                        grantYear = new GrantYearModel();
                        grantYear.Year = reader["Year"].ToString();
                        res.GrantYearList.Add(grantYear);
                    }
                    reader.NextResult();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return res;
        }

        public void GetAward(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }

        public void GetCategory(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }

        public void GetGrantNumber(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }

        public void GetLibrary(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }

        public void GetProject(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }

        public void GetYear(string grantNum, string year, string library, string project, int award)
        {
            throw new NotImplementedException();
        }
    }
}
