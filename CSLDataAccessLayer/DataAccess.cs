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

        public DataTable GetAllGrants(string grantNum, string year, string library, string project, string category, int award)
        {
            DataTable grants = new DataTable();
            SqlConnection conn = new SqlConnection(_dbConnectionString);
            SqlCommand cmd = new SqlCommand("[dbo].[uspSeeAllGrants]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@grantNum", grantNum);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@library", library);
            cmd.Parameters.AddWithValue("@project", project);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@award", award);

            conn.Open();

            try
            {
                var reader = cmd.ExecuteReader();
                grants.Load(reader);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return grants;
        }

        public void GetAward(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }

        public void GetCategory(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }

        public void GetGrantNumber(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }

        public void GetLibrary(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }

        public void GetProject(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }

        public void GetYear(string grantNum, string year, string library, string project, string category, int award)
        {
            throw new NotImplementedException();
        }
    }
}
