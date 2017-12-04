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
    public class SLAAServiceTests
    {
        private static MockDataAccess _dataAccess;
        private static ISLAAService _slaa;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _dataAccess = new MockDataAccess();
            _slaa = new SLAAService(_dataAccess);
        }

        //Test for the method GetAllAgencyCode in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllAgencyCodeTest()
        {
            List<SLAAAgencyModel> myList = new List<SLAAAgencyModel>();
            SLAAAgencyModel myModel = new SLAAAgencyModel() { AgencyCode = "1" };
            myList.Add(new SLAAAgencyModel() { AgencyCode = "All" });
            myList.Add(myModel);
            List<SLAAAgencyModel> res = _slaa.GetAllAgencyCode(1, myModel.AgencyCode);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetAllSLAA in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllSLAATest()
        {
            List<SLAAModel> myList = new List<SLAAModel>();
            SLAAModel myModel = new SLAAModel() { Year = "1", AgencyName = "1ab", AgencyCode = "1" };
            myList.Add(myModel);
            List<SLAAModel> res = _slaa.GetAllSLAA(1, myModel.AgencyCode);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetAllYear in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllYearTest()
        {
            List<SLAAYearModel> myList = new List<SLAAYearModel>();
            SLAAYearModel myModel = new SLAAYearModel() { Year = "1" };
            myList.Add(new SLAAYearModel() { Year = "All" });
            myList.Add(myModel);
            int year = 0;
            int.TryParse(myModel.Year, out year);
            List<SLAAYearModel> res = _slaa.GetAllYear(year, "testCode");

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetYearListValues in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetYearListValuesTest()
        {
            List<SLAAYearModel> myList = new List<SLAAYearModel>();
            SLAAYearModel myModel = new SLAAYearModel() { Year = "1" };
            myList.Add(new SLAAYearModel() { Year = "All" });
            myList.Add(myModel);
            int year = 0;
            int.TryParse(myModel.Year, out year);
            List<string> myStringList = new List<string> { "All", "1" };
            List<string> res = _slaa.GetYearListValues(myList);

            CollectionAssert.AreEqual(myStringList, res);
        }

        //Test for the method GetAgencyCodeListValues in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAgencyCodeListValuesTest()
        {
            List<SLAAAgencyModel> myList = new List<SLAAAgencyModel>();
            SLAAAgencyModel myModel = new SLAAAgencyModel() { AgencyCode = "1" };
            myList.Add(new SLAAAgencyModel() { AgencyCode = "All" });
            myList.Add(myModel);
            int year = 0;
            int.TryParse(myModel.AgencyCode, out year);
            List<string> myStringList = new List<string> { "All", "1" };
            List<string> res = _slaa.GetAgencyCodeListValues(myList);

            CollectionAssert.AreEqual(myStringList, res);
        }

        //Test for the method GetAgencyCodeFromAgencyName in SLAAServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAgencyCodeFromAgencyNameTest()
        {
            string res =_slaa.GetAgencyCodeFromAgencyName("0");

            Assert.AreEqual(res, "0");
        }
    }
}
