﻿using CSLBusinessObjects.ConfigModels;
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

        #region Grants
        public DataTable GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspSeeAllGrants]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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

        //public List<GrantsModel> GetAllGrants(string grantNum, string year, string library, string project, int award)
        //{
        //    List<GrantsModel> res = new List<GrantsModel>();
        //    GrantsModel grantsModel;

        //    string dbConnectionString = _dbConnectionString;
        //    SqlConnection conn = new SqlConnection(dbConnectionString);
        //    SqlCommand cmd = new SqlCommand("[grant].[uspSeeAllGrants]", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
        //    if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
        //    if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
        //    if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
        //    if (award <=7 && award >=0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

        //    conn.Open();

        //    try
        //    {
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                grantsModel = new GrantsModel();
        //                grantsModel.Award = Convert.ToInt32(reader["Award"]);
        //                grantsModel.Library = reader["Library"].ToString();
        //                grantsModel.GrantID = reader["GrantID"].ToString();
        //                grantsModel.Project = reader["Project"].ToString();
        //                grantsModel.Year = reader["Year"].ToString();
        //                res.Add(grantsModel);
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

        public DataTable GetAward(string grantNum, string year, string library, string project, int award)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspFillAwardDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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
        //    SqlCommand cmd = new SqlCommand("[grant].[uspSeeAllGrants]", conn);
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

        public DataTable GetGrantNumber(string grantNum, string year, string library, string project, int award)
        {
            //List<GrantNumberModel> res = new List<GrantNumberModel>();
            //GrantNumberModel init = new GrantNumberModel() { GrantID = "All"};
            //res.Add(init);
            //GrantNumberModel grantNumber;

            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspFillGrantDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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

        public DataTable GetLibrary(string grantNum, string year, string library, string project, int award)
        {
            //List<GrantLibraryModel> res = new List<GrantLibraryModel>();
            //GrantLibraryModel init = new GrantLibraryModel() { Library = "All" };
            //res.Add(init);
            //GrantLibraryModel grantLibrary;

            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspFillLibraryDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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

        public DataTable GetProject(string grantNum, string year, string library, string project, int award)
        {
            //List<GrantProjectModel> res = new List<GrantProjectModel>();
            //GrantProjectModel init = new GrantProjectModel() { Project = "All" };
            //res.Add(init);
            //GrantProjectModel grantProject;

            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspFillProjectDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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

        public DataTable GetYear(string grantNum, string year, string library, string project, int award)
        {
            //List<GrantYearModel> res = new List<GrantYearModel>();
            //GrantYearModel init = new GrantYearModel() { Year = "All" };
            //res.Add(init);
            //GrantYearModel grantYear;

            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[grant].[uspFillYearDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (grantNum != null) { cmd.Parameters.AddWithValue("@GrantFilter", grantNum); }
            if (year != null) { cmd.Parameters.AddWithValue("@YearFilter", year); }
            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (project != null) { cmd.Parameters.AddWithValue("@ProjectFilter", project); }
            if (award <= 7 && award >= 0) { cmd.Parameters.AddWithValue("@AwardFilter", award); }

            conn.Open();

            try
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(res);
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
        #endregion
    }
}
