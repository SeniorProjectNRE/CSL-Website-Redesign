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
using Newtonsoft.Json.Linq;
using System.Net;
using CSLBusinessObjects.Models;

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

        [Route("success")]
        // GET: success
        public ActionResult Success()
        {
            return View("~/Views/WorkWithUs/Jobs/Librarian/Success.cshtml");
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
            try
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
                        return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml", model);
                    }
                }

                if (file != null)
                {
                    string ext = Path.GetExtension(file.FileName);
                    if (ext == ".pdf" || ext == ".doc" || ext == ".docx")
                    {
                        model.ResumeUpload = file;
                    }
                    else model.ResumeUpload = null;
                }

                var response = Request["g-recaptcha-response"];
                string secretKey = "6Lf0XzYUAAAAAEHDxHcYouICuNOMph90Gc1XTOaT";
                var client = new WebClient();
                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result);
                var status = (bool)obj.SelectToken("success");
                ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
                model.IsCaptcha = status;

                if (model.IsCaptcha == false)
                {
                    return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml", model);
                }

                string pdfLibrarianTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LibAppFinal.pdf";
                string pdfSeniorLibrarianTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/SenLibAppFinal.pdf";
                string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

                if (model.IsLibrarian == true && model.IsSeniorLibrarian == false)
                {
                    _examService.FillLibrarianExam(model, pdfLibrarianTemplate, newFile);
                }
                else if (model.IsSeniorLibrarian == true)
                {
                    _examService.FillSeniorLibrarianExam(model, pdfSeniorLibrarianTemplate, newFile);
                }

                bool res = _emailService.SendLibrarianExamEmail(newFile, model);

                if (System.IO.File.Exists(HostingEnvironment.MapPath(newFile)))
                {
                    System.IO.File.Delete(HostingEnvironment.MapPath(newFile));
                }

                if (res == false)
                {
                    return RedirectToAction("EmailError", "error");
                }

                ModelState.Clear();
                model.Success = res;
                //return View("~/Views/WorkWithUs/Jobs/Librarian/Apply.cshtml", model);
                return RedirectToAction("success", "librarian");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "error");
            }
        }
    }
}