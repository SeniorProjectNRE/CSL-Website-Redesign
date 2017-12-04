using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSLBusinessLayer.Interface;
using CSL.Tests.DataAccess;
using CSLBusinessObjects.ViewModels;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.Models.Exams;
using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Tests.ExamService;

namespace CSL.Tests.BusinessLayer
{
    /// <summary>
    /// Summary description for GrantsServiceTests
    /// </summary>
    [TestClass]
    public class ExamServiceTests
    {

        private static IExamService _exam;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _exam = new ExamService();
        }

        //Test for the method FillLibrarianExam in LibraryServices.cs in CSLBusinessLayer
        [TestMethod]
        public void Service_FillLibrarianExamTest()
        {
            LibrarianModel test = new LibrarianModel() { Name = "Librarian", Signature = "sig", Date = "111111", SearchStrategies = "2er" };
            string pdfLibrarianTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LibAppFinal.pdf";
            string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + test.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";
            bool res = _exam.FillLibrarianExam(test, pdfLibrarianTemplate, newFile);

            Assert.AreEqual(res, true);
        }


    }
}
