using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.Librarian
{
    [RoutePrefix("work-with-us/jobs/librarian")]
    public class LibrarianController : Controller
    {
        private IExamService _examService;
        private IEmailService _emailService;

        public LibrarianController(IEmailService emailService, IExamService examService)
        {
            _emailService = emailService;
            _examService = examService;
        }

        [Route("")]
        // GET: Librarian
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/Librarian/Librarian.cshtml");
        }

        [HttpGet]
        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
        }

        [HttpPost]
        [Route("apply")]
        public ActionResult Apply(LibrarianModel model)
        {
            string pdfTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LibAppFinal.pdf";
            string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

            _examService.FillForm(model, pdfTemplate, newFile);
            return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
        }
    }
}