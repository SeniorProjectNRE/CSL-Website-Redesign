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

        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
        }

        [Route("apply")]
        public ActionResult Apply(LibrarianModel model)
        {
            string pdfTemplate = "~/Content/StateTemplate/pdf/";
            _examService.FillForm(model, );
            return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
        }
    }
}