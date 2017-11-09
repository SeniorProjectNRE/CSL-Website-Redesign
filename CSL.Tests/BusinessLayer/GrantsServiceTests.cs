using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSLBusinessLayer.Interface;
using CSL.Tests.DataAccess;
using CSLBusinessLayer.Concrete;
using CSLBusinessObjects.ViewModels;

namespace CSL.Tests.BusinessLayer
{
    /// <summary>
    /// Summary description for GrantsServiceTests
    /// </summary>
    [TestClass]
    public class GrantsServiceTests
    {
        private static MockDataAccess _dataAccess;
        private static IGrantsService _grant;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _dataAccess = new MockDataAccess();
            _grant = new GrantsService(_dataAccess);
        }

        [TestMethod]
        public void Service_GetAwardTest()
        {
            List<GrantAwardModel> myList = new List<GrantAwardModel>();
            GrantAwardModel myModel = new GrantAwardModel() { Award = 1000 };
            myList.Add(myModel);
            List<GrantAwardModel> res = _grant.GetAllAwards("testNum", "testYear", "testLibrary", "testProject", (int)myModel.Award);

            Assert.ReferenceEquals(myList, res);
        }
    }
}
