using CSLBusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using CSLDataAccessLayer;
using System.Data;

namespace CSLBusinessLayer.Concrete
{
    public class LibraryService : ILibraryService
    {
        private IDataAccess _dataAccess;


        public LibraryService(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public List<LibraryModel> GetAllBroadband(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetAllBroadband(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryModel> res = new List<LibraryModel>();
            LibraryModel myModel;

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryModel()
                    {
                        LibraryName = row["LibraryName"].ToString(),
                        Jurisdiction = row["Jurisdiction"].ToString(),
                        CLSA = row["CLSA"].ToString(),
                        City = row["City"].ToString(),
                        County = row["County"].ToString(),
                        Zip = row["Zip"].ToString(),
                        AssemblyDistrict = row["AssemblyDistrict"].ToString(),
                        SenateDistrict = row["SenateDistrict"].ToString(),
                        CongressionalDistrict = row["CongressionalDistrict"].ToString(),
                        Status = row["Status"].ToString() + ": " + row["StatusCode"].ToString()
                        //StatusCode = row["StatusCode"].ToString()


                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<LibraryAssemblyModel> GetAssembly(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetAssembly(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryAssemblyModel> res = new List<LibraryAssemblyModel>();
            LibraryAssemblyModel myModel;
            LibraryAssemblyModel allModel = new LibraryAssemblyModel() { AssemblyDistrict = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryAssemblyModel()
                    {
                        AssemblyDistrict = row["AssemblyDistrict"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetAssemblyListValues(List<LibraryAssemblyModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.AssemblyDistrict;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryCityModel> GetCity(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetCity(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCityModel> res = new List<LibraryCityModel>();
            LibraryCityModel myModel;
            LibraryCityModel allModel = new LibraryCityModel() { City = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryCityModel()
                    {
                        City = row["City"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetCityListValues(List<LibraryCityModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.City;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryCLSAModel> GetCLSA(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetCLSA(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCLSAModel> res = new List<LibraryCLSAModel>();
            LibraryCLSAModel myModel;
            LibraryCLSAModel allModel = new LibraryCLSAModel() { CLSA = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryCLSAModel()
                    {
                        CLSA = row["CLSA"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetCLSAListValues(List<LibraryCLSAModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.CLSA;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryCodeModel> GetCode(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetCode(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCodeModel> res = new List<LibraryCodeModel>();
            LibraryCodeModel myModel;
            LibraryCodeModel allModel = new LibraryCodeModel() { StatusCode = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryCodeModel()
                    {
                        StatusCode = row["StatusCode"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetCodeListValues(List<LibraryCodeModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.StatusCode;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryCongressionalModel> GetCongress(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetCongress(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCongressionalModel> res = new List<LibraryCongressionalModel>();
            LibraryCongressionalModel myModel;
            LibraryCongressionalModel allModel = new LibraryCongressionalModel() { CongressionalDistrict = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryCongressionalModel()
                    {
                        CongressionalDistrict = row["CongressionalDistrict"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetCongressListValues(List<LibraryCongressionalModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.CongressionalDistrict;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryCountyModel> GetCounty(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetCounty(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCountyModel> res = new List<LibraryCountyModel>();
            LibraryCountyModel myModel;
            LibraryCountyModel allModel = new LibraryCountyModel() { County = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryCountyModel()
                    {
                        County = row["County"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetCountyListValues(List<LibraryCountyModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.County;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryJurisdictionModel> GetJurisdiction(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetJurisdiction(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryJurisdictionModel> res = new List<LibraryJurisdictionModel>();
            LibraryJurisdictionModel myModel;
            LibraryJurisdictionModel allModel = new LibraryJurisdictionModel() { Jurisdiction = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryJurisdictionModel()
                    {
                        Jurisdiction = row["Jurisdiction"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetJurisdictionListValues(List<LibraryJurisdictionModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Jurisdiction;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryLibraryModel> GetLibrary(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetLibrary(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryLibraryModel> res = new List<LibraryLibraryModel>();
            LibraryLibraryModel myModel;
            LibraryLibraryModel allModel = new LibraryLibraryModel() { LibraryName = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryLibraryModel()
                    {
                        LibraryName = row["LibraryName"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetLibraryListValues(List<LibraryLibraryModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.LibraryName;
                res.Add(value);
            }
            return res;
        }

        public List<LibrarySenateModel> GetSenate(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetSenate(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibrarySenateModel> res = new List<LibrarySenateModel>();
            LibrarySenateModel myModel;
            LibrarySenateModel allModel = new LibrarySenateModel() { SenateDistrict = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibrarySenateModel()
                    {
                        SenateDistrict = row["SenateDistrict"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetSenateListValues(List<LibrarySenateModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.SenateDistrict;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryStatusModel> GetStatus(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetStatus(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryStatusModel> res = new List<LibraryStatusModel>();
            LibraryStatusModel myModel;
            LibraryStatusModel allModel = new LibraryStatusModel() { Status = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryStatusModel()
                    {
                        Status = row["Status"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetStatusListValues(List<LibraryStatusModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Status;
                res.Add(value);
            }
            return res;
        }

        public List<LibraryZipModel> GetZip(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myData = _dataAccess.GetZip(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryZipModel> res = new List<LibraryZipModel>();
            LibraryZipModel myModel;
            LibraryZipModel allModel = new LibraryZipModel() { Zip = "All" };
            res.Add(allModel);

            try
            {
                foreach (DataRow row in myData.Rows)
                {
                    myModel = new LibraryZipModel()
                    {
                        Zip = row["Zip"].ToString()
                    };
                    res.Add(myModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public List<string> GetZipListValues(List<LibraryZipModel> model)
        {
            List<string> res = new List<string>();
            foreach (var item in model)
            {
                string value = item.Zip;
                res.Add(value);
            }
            return res;
        }
    }
}
