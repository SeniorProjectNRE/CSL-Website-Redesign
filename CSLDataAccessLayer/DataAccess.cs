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
        #endregion

        #region Library
        public DataTable GetAssembly(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillAssemblyDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetCity(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillCityDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetCLSA(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillCLSADDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetCongress(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillCongressionalDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetCounty(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillCountyDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetJurisdiction(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillJurisdictionDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetLibrary(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillLibraryDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetSenate(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillSenateDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetCode(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillStatusCodeDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetStatus(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillStatusDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetZip(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspFillZipCodeDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        public DataTable GetAllBroadband(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[library].[uspSeeAllBroadband]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (library != null) { cmd.Parameters.AddWithValue("@LibraryFilter", library); }
            if (jurisdiction != null) { cmd.Parameters.AddWithValue("@JurisdictionFilter", jurisdiction); }
            if (csla != null) { cmd.Parameters.AddWithValue("@CLSAFilter", csla); }
            if (city != null) { cmd.Parameters.AddWithValue("@CityFilter", city); }
            if (county != null) { cmd.Parameters.AddWithValue("@CountyFilter", county); }
            if (zip < 0) { cmd.Parameters.AddWithValue("@ZipCodeFilter", zip); }
            if (assembly < 0) { cmd.Parameters.AddWithValue("@AssemblyFilter", assembly); }
            if (senate < 0) { cmd.Parameters.AddWithValue("@SenateFilter", senate); }
            if (congress < 0) { cmd.Parameters.AddWithValue("@CongressionalFilter", congress); }
            if (status != null) { cmd.Parameters.AddWithValue("@StatusFilter", status); }
            if (code != null) { cmd.Parameters.AddWithValue("@StatusCodeFilter", code); }

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

        #region SLAA
        public DataTable GetAllSLAA(int year, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[slaa].[uspSeeAllCases]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (code != null) { cmd.Parameters.AddWithValue("@AgencyCodeFilter", code); }
            if (year != 0) { cmd.Parameters.AddWithValue("@YearFilter", year); }

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

        public DataTable GetAgencyCode(int year, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[slaa].[uspFillAgencyDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (code != null) { cmd.Parameters.AddWithValue("@AgencyCodeFilter", code); }
            if (year != 0) { cmd.Parameters.AddWithValue("@YearFilter", year); }

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

        public DataTable GetYear(int year, string code)
        {
            DataTable res = new DataTable();

            string dbConnectionString = _dbConnectionString;
            SqlConnection conn = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("[slaa].[uspFillYearDDL]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (code != null) { cmd.Parameters.AddWithValue("@AgencyCodeFilter", code); }
            if (year != 0) { cmd.Parameters.AddWithValue("@YearFilter", year); }

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
