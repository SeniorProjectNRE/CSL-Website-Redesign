using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models.Exams;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.LibraryProgramAdmin
{
    [RoutePrefix("work-with-us/jobs/Library-Program-Admin")]
    public class LibraryProgramAdminController : Controller
    {
        private IExamService _examService;
        private IEmailService _emailService;

        public LibraryProgramAdminController(IEmailService emailService, IExamService examService)
        {
            _emailService = emailService;
            _examService = examService;
        }

        [Route("")]
        // GET: LibraryProgramAdmin
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/LibraryProgramAdmin.cshtml");
        }

        [Route("success")]
        // GET: success
        public ActionResult Success()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/Success.cshtml");
        }

        [HttpGet]
        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/Apply.cshtml");
        }

        [HttpPost]
        [Route("apply")]
        public ActionResult Apply(LPAModel model, HttpPostedFileBase file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/Apply.cshtml", model);
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
                    return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/Apply.cshtml", model);
                }

                string pdfLPAtemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LPAAppFinal.pdf";
                string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

                _examService.FillLPAExam(model, pdfLPAtemplate, newFile);


                bool res = _emailService.SendLPAExamEmail(newFile, model);

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
                return RedirectToAction("success", "libraryprogramadmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "error");
            }
        }
    }
}