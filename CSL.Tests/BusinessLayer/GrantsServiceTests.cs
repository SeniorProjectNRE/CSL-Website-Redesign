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

        //Test for the method GetAllGrantIDs in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetGrantNumTest()
        {
            List<GrantNumberModel> myList = new List<GrantNumberModel>();
            GrantNumberModel myModelAll = new GrantNumberModel() { GrantID = "All" };
            GrantNumberModel myModel = new GrantNumberModel() { GrantID = "8000"};
            myList.Add(myModelAll);
            myList.Add(myModel);
            List<GrantNumberModel> res = _grant.GetAllGrantIDs(myModel.GrantID, "testYear", "testLibrary", "testProject", 0);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.ReferenceEquals(myList[i], res[i]);
            }
        }

        //Test for the method GetAllAwards in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAwardTest()
        {
            List<GrantAwardModel> myList = new List<GrantAwardModel>();
            GrantAwardModel myModel = new GrantAwardModel() { Award = 1000 };
            myList.Add(myModel);
            List<GrantAwardModel> res = _grant.GetAllAwards("testNum", "testYear", "testLibrary", "testProject", (int)myModel.Award);

            CollectionAssert.ReferenceEquals(myList, res);
        }

        //Test for the method GetAllGrants in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllGrantsTest()
        {
            List<GrantsModel> myList = new List<GrantsModel>();
            GrantsModel myModel = new GrantsModel() { GrantID = "1", Library = "aaa", Project = "bbb", Award = "1000", Year = "1"  };
            myList.Add(myModel);
            int award = 0;
            int.TryParse(myModel.Award, out award);
            List<GrantsModel> res = _grant.GetAllGrants(myModel.GrantID, myModel.Year, myModel.Library, myModel.Project, award);

            CollectionAssert.ReferenceEquals(myList, res);
        }

        //Test for the method GetAllLibraries in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllLibrariesTest()
        {
            List<GrantLibraryModel> myList = new List<GrantLibraryModel>();
            GrantLibraryModel myModel = new GrantLibraryModel() { Library = "aaa"};
            myList.Add(myModel);
            List<GrantLibraryModel> res = _grant.GetAllLibraries("testNum", "testYear", myModel.Library, "testProject", 1);

            CollectionAssert.ReferenceEquals(myList, res);
        }

        //Test for the method GetAllProjects in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllProjectsTest()
        {
            List<GrantProjectModel> myList = new List<GrantProjectModel>();
            GrantProjectModel myModel = new GrantProjectModel() { Project = "bbb" };
            myList.Add(myModel);
            List<GrantProjectModel> res = _grant.GetAllProjects("testNum", "testYear", "testLibrary", myModel.Project, 1);

            CollectionAssert.ReferenceEquals(myList, res);
        }

        //Test for the method GetAllYears in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAllYearsTest()
        {
            List<GrantYearModel> myList = new List<GrantYearModel>();
            GrantYearModel myModel = new GrantYearModel() { Year = "1" };
            myList.Add(myModel);
            List<GrantYearModel> res = _grant.GetAllYears("testNum", myModel.Year, "testLibrary", "testProject", 1);

            CollectionAssert.ReferenceEquals(myList, res);
        }

        //Test for the method GetAwardCategoryFromString in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAwardCategoryTest()
        {
            int test = 1;
            string testInput = "100";
            int res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);

            test = 2;
            testInput = "15000";
            res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);

            test = 3;
            testInput = "55000";
            res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);

            test = 4;
            testInput = "155000";
            res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);

            test = 5;
            testInput = "555000";
            res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);

            test = 6;
            testInput = "1555000";
            res = _grant.GetAwardCategoryFromString(testInput);

            Assert.AreEqual(test, res);
        }

        //Test for the method GetAwardListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetAwardListValuesTest()
        {
            List<GrantAwardModel> modelList = _grant.GetAllAwards("testNum", "testYear", "testLibrary", "testProject", 1000);

            List<int> myList = new List<int>();
            int award = 1000;
            myList.Add(award);
            List<int> res = _grant.GetAwardListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetLibrariesListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetLibrariesListValuesTest()
        {
            List<GrantLibraryModel> modelList = _grant.GetAllLibraries("testNum", "testYear", "testLibrary", "testProject", 1000);

            List<string> myList = new List<string>();
            myList.Add("All");
            myList.Add("testLibrary");
            List<string> res = _grant.GetLibrariesListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetNumListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetNumListValuesTest()
        {
            List<GrantNumberModel> modelList = _grant.GetAllGrantIDs("testNum", "testYear", "testLibrary", "testProject", 1000);

            List<string> myList = new List<string>();
            myList.Add("All");
            myList.Add("testNum");
            List<string> res = _grant.GetNumListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetProjectListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetProjectListValuesTest()
        {
            List<GrantProjectModel> modelList = _grant.GetAllProjects("testNum", "testYear", "testLibrary", "testProject", 1);

            List<string> myList = new List<string>();
            myList.Add("All");
            myList.Add("testProject");
            List<string> res = _grant.GetProjectListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }

        //Test for the method GetYearListValues in GrantsServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_GetYearListValuesTest()
        {
            List<GrantYearModel> modelList = _grant.GetAllYears("testNum", "testYear", "testLibrary", "testProject", 1000);

            List<string> myList = new List<string>();
            myList.Add("All");
            myList.Add("testYear");
            List<string> res = _grant.GetYearListValues(modelList);

            CollectionAssert.AreEqual(myList, res);
        }
    }
}
