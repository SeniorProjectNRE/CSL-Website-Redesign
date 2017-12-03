using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSLBusinessLayer.Interface;
using CSL.Tests.DataAccess;
using CSLBusinessLayer.Concrete;
using CSLBusinessObjects.ViewModels;
using CSLBusinessObjects.Models;

namespace CSL.Tests.BusinessLayer
{
    /// <summary>
    /// Summary description for SLAAServiceTests
    /// </summary>
    [TestClass]
    public class LibraryServiceTests
    {
        private static MockDataAccess _dataAccess;
        private static ILibraryService _library;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _dataAccess = new MockDataAccess();
            _library = new LibraryService(_dataAccess);
        }

        //Test for the method GetAllBroadband in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllBroadbandTest()
        {
            List<LibraryModel> myList = new List<LibraryModel>();
            LibraryModel myModel = new LibraryModel() { LibraryName = "aaa", Jurisdiction = "bbb", CLSA = "ccc", City = "ddd", County = "eee", Zip = "12345", AssemblyDistrict = "1", SenateDistrict = "2", CongressionalDistrict = "3", Status = "123", StatusCode = "321"};
            myList.Add(myModel);
            int zip = 0, assembly = 0, senate = 0, congress = 0;
            int.TryParse(myModel.Zip, out zip);
            int.TryParse(myModel.AssemblyDistrict, out assembly);
            int.TryParse(myModel.SenateDistrict, out senate);
            int.TryParse(myModel.CongressionalDistrict, out congress);
            List<LibraryModel> res = _library.GetAllBroadband(myModel.LibraryName, myModel.Jurisdiction, myModel.CLSA, myModel.City, myModel.County, zip, assembly, senate, congress, myModel.Status, myModel.StatusCode);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetAssembly in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAssemblyTest()
        {
            List<LibraryAssemblyModel> myList = new List<LibraryAssemblyModel>();
            LibraryAssemblyModel myModel = new LibraryAssemblyModel() { AssemblyDistrict = "1"};
            myList.Add(new LibraryAssemblyModel() { AssemblyDistrict = "All" });
            myList.Add(myModel);
            int assembly = 0;
            int.TryParse(myModel.AssemblyDistrict, out assembly);
            List<LibraryAssemblyModel> res = _library.GetAssembly("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, assembly, 2, 3, "testStatus", "testStatusCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetAssemblyListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAssemblyListValuesTest()
        {
            List<LibraryAssemblyModel> modelList = _library.GetAssembly("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string assembly = "4";
            myList.Add("All");
            myList.Add(assembly);
            List<string> res = _library.GetAssemblyListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetCity in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCityTest()
        {
            List<LibraryCityModel> myList = new List<LibraryCityModel>();
            LibraryCityModel myModel = new LibraryCityModel() { City = "aaa" };
            myList.Add(new LibraryCityModel() { City = "All" });
            myList.Add(myModel);
            List<LibraryCityModel> res = _library.GetCity("testName", "testJurisdiction", "testCLSA", myModel.City, "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetCityListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCityListValuesTest()
        {
            List<LibraryCityModel> modelList = _library.GetCity("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string city = "testCity";
            myList.Add("All");
            myList.Add(city);
            List<string> res = _library.GetCityListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetCity in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCSLATest()
        {
            List<LibraryCLSAModel> myList = new List<LibraryCLSAModel>();
            LibraryCLSAModel myModel = new LibraryCLSAModel() { CLSA = "aaa" };
            myList.Add(new LibraryCLSAModel() { CLSA = "All" });
            myList.Add(myModel);
            List<LibraryCLSAModel> res = _library.GetCLSA("testName", "testJurisdiction", myModel.CLSA, "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetCLSAListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCLSAListValuesTest()
        {
            List<LibraryCLSAModel> modelList = _library.GetCLSA("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string clsa = "testCLSA";
            myList.Add("All");
            myList.Add(clsa);
            List<string> res = _library.GetCLSAListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetCity in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCodeTest()
        {
            List<LibraryCodeModel> myList = new List<LibraryCodeModel>();
            LibraryCodeModel myModel = new LibraryCodeModel() { StatusCode = "aaa" };
            myList.Add(new LibraryCodeModel() { StatusCode = "All" });
            myList.Add(myModel);
            List<LibraryCodeModel> res = _library.GetCode("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", myModel.StatusCode);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetCodeListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCodeListValuesTest()
        {
            List<LibraryCodeModel> modelList = _library.GetCode("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string code = "testStatusCode";
            myList.Add("All");
            myList.Add(code);
            List<string> res = _library.GetCodeListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetCongress in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCongressTest()
        {
            List<LibraryCongressionalModel> myList = new List<LibraryCongressionalModel>();
            LibraryCongressionalModel myModel = new LibraryCongressionalModel() { CongressionalDistrict = "56" };
            myList.Add(new LibraryCongressionalModel() { CongressionalDistrict = "All" });
            myList.Add(myModel);
            int congress = 0;
            int.TryParse(myModel.CongressionalDistrict, out congress);
            List<LibraryCongressionalModel> res = _library.GetCongress("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, congress, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetCongressListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCongressListValuesTest()
        {
            List<LibraryCongressionalModel> modelList = _library.GetCongress("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string congress = "3";
            myList.Add("All");
            myList.Add(congress);
            List<string> res = _library.GetCongressListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetCounty in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCountyTest()
        {
            List<LibraryCountyModel> myList = new List<LibraryCountyModel>();
            LibraryCountyModel myModel = new LibraryCountyModel() { County = "6" };
            myList.Add(new LibraryCountyModel() { County = "All" });
            myList.Add(myModel);
            List<LibraryCountyModel> res = _library.GetCounty("testName", "testJurisdiction", "testCLSA", "testCity", myModel.County, 1, 4, 2, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetCountyListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetCountyListValuesTest()
        {
            List<LibraryCountyModel> modelList = _library.GetCounty("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string county = "testCounty";
            myList.Add("All");
            myList.Add(county);
            List<string> res = _library.GetCountyListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetJurisdiction in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetJurisdictionTest()
        {
            List<LibraryJurisdictionModel> myList = new List<LibraryJurisdictionModel>();
            LibraryJurisdictionModel myModel = new LibraryJurisdictionModel() { Jurisdiction = "6" };
            myList.Add(new LibraryJurisdictionModel() { Jurisdiction = "All" });
            myList.Add(myModel);
            List<LibraryJurisdictionModel> res = _library.GetJurisdiction("testName", myModel.Jurisdiction, "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetJurisdictionListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetJurisdictionListValuesTest()
        {
            List<LibraryJurisdictionModel> modelList = _library.GetJurisdiction("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string jur = "testJurisdiction";
            myList.Add("All");
            myList.Add(jur);
            List<string> res = _library.GetJurisdictionListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetLibrary in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetLibraryTest()
        {
            List<LibraryLibraryModel> myList = new List<LibraryLibraryModel>();
            LibraryLibraryModel myModel = new LibraryLibraryModel() { LibraryName = "testName" };
            myList.Add(new LibraryLibraryModel() { LibraryName = "All" });
            myList.Add(myModel);
            List<LibraryLibraryModel> res = _library.GetLibrary(myModel.LibraryName, "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetLibraryListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetLibraryListValuesTest()
        {
            List<LibraryLibraryModel> modelList = _library.GetLibrary("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string name = "testName";
            myList.Add("All");
            myList.Add(name);
            List<string> res = _library.GetLibraryListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetSenate in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetSenateTest()
        {
            List<LibrarySenateModel> myList = new List<LibrarySenateModel>();
            LibrarySenateModel myModel = new LibrarySenateModel() { SenateDistrict = "testName" };
            myList.Add(new LibrarySenateModel() { SenateDistrict = "All" });
            myList.Add(myModel);
            int senate = 0;
            int.TryParse(myModel.SenateDistrict, out senate);
            List<LibrarySenateModel> res = _library.GetSenate("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, senate, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetSenateListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetSenateListValuesTest()
        {
            List<LibrarySenateModel> modelList = _library.GetSenate("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string senate = "2";
            myList.Add("All");
            myList.Add(senate);
            List<string> res = _library.GetSenateListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetStatus in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetStatusTest()
        {
            List<LibraryStatusModel> myList = new List<LibraryStatusModel>();
            LibraryStatusModel myModel = new LibraryStatusModel() { Status = "testName" };
            myList.Add(new LibraryStatusModel() { Status = "All" });
            myList.Add(myModel);

            List<LibraryStatusModel> res = _library.GetStatus(myModel.Status, "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetStatusListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetStatusListValuesTest()
        {
            List<LibraryStatusModel> modelList = _library.GetStatus("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string status = "testStatus";
            myList.Add("All");
            myList.Add(status);
            List<string> res = _library.GetStatusListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetZip in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetZipTest()
        {
            List<LibraryZipModel> myList = new List<LibraryZipModel>();
            LibraryZipModel myModel = new LibraryZipModel() { Zip = "testName" };
            myList.Add(new LibraryZipModel() { Zip = "All" });
            myList.Add(myModel);
            int zip = 0;
            int.TryParse(myModel.Zip, out zip);
            List<LibraryZipModel> res = _library.GetZip("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", zip, 4, 2, 3, "testStatus", "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetZipListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetZipListValuesTest()
        {
            List<LibraryZipModel> modelList = _library.GetZip("testName", "testJurisdiction", "testCLSA", "testCity", "testCounty", 1, 4, 2, 3, "testStatus", "testStatusCode");

            List<string> myList = new List<string>();
            string zip = "1";
            myList.Add("All");
            myList.Add(zip);
            List<string> res = _library.GetZipListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

    }
}
