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

        public List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            List<GrantsModel> res = new List<GrantsModel>();
            //res.GrantAwardList = new List<GrantAwardModel>();
            //res.GrantCategoryList = new List<GrantCategoryModel>();
            //res.GrantGetAllList = new List<GrantsModel>();
            //res.GrantLibraryList = new List<GrantLibraryModel>();
            //res.GrantNumberList = new List<GrantNumberModel>();
            //res.GrantProjectList = new List<GrantProjectModel>();
            //res.GrantYearList = new List<GrantYearModel>();
            GrantsModel grantsModel;


            //string dbConnectionString = @"Data Source=csldata.database.windows.net;Initial Catalog=LSTAGrants;User ID=csl;Password=Testing!23";
            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspSeeAllGrants]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <=7 && award >=0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            //cmd.Parameters.AddWithValue("@GrantFilter", grantNum);
            //cmd.Parameters.AddWithValue("@YearFilter", year);
            //cmd.Parameters.AddWithValue("@LibraryFilter", library);
            //cmd.Parameters.AddWithValue("@ProjectFilter", project);
            //cmd.Parameters.AddWithValue("@AwardFilter", award);

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantsModel = new GrantsModel();
                        grantsModel.Award = Convert.ToInt32(reader["Award"]);
                        grantsModel.Library = reader["Library"].ToString();
                        grantsModel.GrantID = reader["GrantID"].ToString();
                        grantsModel.Project = reader["Project"].ToString();
                        grantsModel.Year = reader["Year"].ToString();
                        res.Add(grantsModel);
                    }

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

        public List<GrantAwardModel>GetAward(string grantNum, string year, string library, string project, int award)
        {
            List<GrantAwardModel> res = new List<GrantAwardModel>();
            GrantAwardModel init = new GrantAwardModel() { Award = 0 };
            res.Add(init);
            GrantAwardModel grantAward;

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspFillAwardDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantAward = new GrantAwardModel();
                        grantAward.Award = Convert.ToInt32(reader["Award"]);
                        res.Add(grantAward);
                    }
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

        //public List<GrantCategoryModel> GetCategory(string grantNum, string year, string library, string project, int award)
        //{
        //    GrantsViewModel res = new GrantsViewModel();
        //    res.GrantCategoryList = new List<GrantCategoryModel>();
        //    GrantCategoryModel grantCategory;

        //    string dbConnectionString = _dbConnectionString;
        //    SqlConnection conn = new SqlConnection(dbConnectionString);
        //    SqlCommand cmd = new SqlCommand("[dbo].[uspSeeAllGrants]", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
        //    if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
        //    if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
        //    if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
        //    if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

        //    try
        //    {
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                grantCategory = new GrantCategoryModel();
        //                grantCategory.Category = Convert.ToInt32(reader["Category"]);
        //                res.GrantCategoryList.Add(grantCategory);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return res;
        //}

        public List<GrantNumberModel> GetGrantNumber(string grantNum, string year, string library, string project, int award)
        {
            List<GrantNumberModel> res = new List<GrantNumberModel>();
            GrantNumberModel init = new GrantNumberModel() { GrantID = "All"};
            res.Add(init);
            GrantNumberModel grantNumber;

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspFillGrantDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantNumber = new GrantNumberModel();
                        grantNumber.GrantID = reader["GrantID"].ToString();
                        res.Add(grantNumber);
                    }
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

        public List<GrantLibraryModel> GetLibrary(string grantNum, string year, string library, string project, int award)
        {
            List<GrantLibraryModel> res = new List<GrantLibraryModel>();
            GrantLibraryModel init = new GrantLibraryModel() { Library = "All" };
            res.Add(init);
            GrantLibraryModel grantLibrary;

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspFillLibraryDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantLibrary = new GrantLibraryModel();
                        grantLibrary.Library = reader["Library"].ToString();
                        res.Add(grantLibrary);
                    }
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

        public List<GrantProjectModel> GetProject(string grantNum, string year, string library, string project, int award)
        {
            List<GrantProjectModel> res = new List<GrantProjectModel>();
            GrantProjectModel init = new GrantProjectModel() { Project = "All" };
            res.Add(init);
            GrantProjectModel grantProject;

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspFillProjectDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantProject = new GrantProjectModel();
                        grantProject.Project = reader["Project"].ToString();
                        res.Add(grantProject);
                    }
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

        public List<GrantYearModel> GetYear(string grantNum, string year, string library, string project, int award)
        {
            List<GrantYearModel> res = new List<GrantYearModel>();
            GrantYearModel init = new GrantYearModel() { Year = "All" };
            res.Add(init);
            GrantYearModel grantYear;

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspFillYearDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        grantYear = new GrantYearModel();
                        grantYear.Year = reader["Year"].ToString();
                        res.Add(grantYear);
                    }
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
    }
}
