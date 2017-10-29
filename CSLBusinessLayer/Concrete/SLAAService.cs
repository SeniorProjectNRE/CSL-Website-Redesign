using CSLBusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CSLBusinessObjects.Models;
using CSLDataAccessLayer;

namespace CSLBusinessLayer.Concrete
{
    public class SLAAService : ISLAAService
    {
        private IDataAccess _dataAccess;


        public SLAAService(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public List<string> GetAgencyCodeListValues(List<SLAAAgencyModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.AgencyCode;
                res.Add(value);
            }
            return res;
        }

        public List<SLAAAgencyModel> GetAllAgencyCode(int year, string code)
        {
            DataTable myData = _dataAccess.GetAgencyCode(year, code);
            List<SLAAAgencyModel> res = new List<SLAAAgencyModel>();
            SLAAAgencyModel slaaAgencyModel;
            SLAAAgencyModel allModel = new SLAAAgencyModel() { AgencyCode = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    slaaAgencyModel = new SLAAAgencyModel()
                    {
                        AgencyCode = row["ReportAgencyName"].ToString()
                    };
                    res.Add(slaaAgencyModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<SLAAModel> GetAllSLAA(int year, string code)
        {
            DataTable myData = _dataAccess.GetAllSLAA(year, code);
            List<SLAAModel> res = new List<SLAAModel>();
            SLAAModel slaaModel;

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    slaaModel = new SLAAModel()
                    {
                        Year = Convert.ToInt32(row["ReportYear"]).ToString(),
                        AgencyCode = row["ReportAgencyCode"].ToString(),
                        AgencyName = row["ReportAgencyName"].ToString()
                    };
                    res.Add(slaaModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<SLAAYearModel> GetAllYear(int year, string code)
        {
            DataTable myData = _dataAccess.GetYear(year, code);
            List<SLAAYearModel> res = new List<SLAAYearModel>();
            SLAAYearModel slaaYearModel;
            SLAAYearModel allModel = new SLAAYearModel() { Year = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    slaaYearModel = new SLAAYearModel()
                    {
                        Year = Convert.ToInt32(row["Year"]).ToString()
                    };
                    res.Add(slaaYearModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetYearListValues(List<SLAAYearModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Year;
                res.Add(value);
            }
            return res;
        }

        public string GetAgencyCodeFromAgencyName(string name)
        {
            string res = null;
            List<SLAAModel> myModels = GetAllSLAA(0, null);
            string myName = name;

            foreach(var item in myModels)
            {
                if(item.AgencyName.Trim() == name)
                {
                    res = item.AgencyCode;
                    return res;
                }
            }
            return res;   
        }
    }
}
