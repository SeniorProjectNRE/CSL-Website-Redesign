using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.IO;
using System.Threading;

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
        public ActionResult Apply(LibrarianModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                if (model.IsLibrarian == true && model.IsSeniorLibrarian == false)
                {
                    ModelState.Remove("Q7");
                    ModelState.Remove("NameQ7");
                    ModelState.Remove("EmailQ7");
                    ModelState.Remove("PhoneNumQ7");
                    ModelState.Remove("Q8");
                    ModelState.Remove("NameQ8");
                    ModelState.Remove("EmailQ8");
                    ModelState.Remove("PhoneNumQ8");
                }
                if (!ModelState.IsValid)
                {
                    return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
                }
            }

            string ext = Path.GetExtension(file.FileName);
            if (ext == ".pdf" || ext == ".doc" || ext == ".docx")
            {
                model.ResumeUpload = file;
            }
            else model.ResumeUpload = null;
            

            string pdfTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LibAppFinal.pdf";
            string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

            _examService.FillLibrarianExam(model, pdfTemplate, newFile);

            

            _emailService.SendLibrarianExamEmail(newFile, model);

            if (System.IO.File.Exists(HostingEnvironment.MapPath(newFile)))
            {
                System.IO.File.Delete(HostingEnvironment.MapPath(newFile));
            }




            return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml");
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}