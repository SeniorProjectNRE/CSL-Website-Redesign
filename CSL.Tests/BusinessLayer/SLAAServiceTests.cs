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
    /// Summary description for GrantsServiceTests
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

        [TestMethod]
        public void Service_GetAllAgencyCodeTest()
        {
            List<SLAAAgencyModel> myList = new List<SLAAAgencyModel>();
            SLAAAgencyModel myModel = new SLAAAgencyModel() { AgencyCode = "1" };
            myList.Add(myModel);
            List<SLAAAgencyModel> res = _slaa.GetAllAgencyCode(1, myModel.AgencyCode);

            Assert.ReferenceEquals(myList, res);
        }
    }
}
