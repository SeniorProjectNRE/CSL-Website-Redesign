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

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.LibraryTechnicalAssistant
{
    [RoutePrefix("work-with-us/jobs/Library-Technical-Assistant")]
    public class LibraryTechnicalAssistantController : Controller
    {
        private IExamService _examService;
        private IEmailService _emailService;

        public LibraryTechnicalAssistantController(IEmailService emailService, IExamService examService)
        {
            _emailService = emailService;
            _examService = examService;
        }

        // GET: LibraryTechnicalAssistant
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/LibraryTechnicalAssistant.cshtml");
        }

        [Route("success")]
        // GET: success
        public ActionResult Success()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/Success.cshtml");
        }

        // GET: Apply
        [HttpGet]
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/Apply.cshtml");
        }

        [HttpPost]
        [Route("apply")]
        public ActionResult Apply(LTAModel model, HttpPostedFileBase file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (model.IsLTAI == true && model.IsLTAII == false)
                    {
                        ModelState.Remove("Q4");
                        ModelState.Remove("NameQ4");
                        ModelState.Remove("EmailQ4");
                        ModelState.Remove("PhoneNumQ4");
                        ModelState.Remove("Q5");
                        ModelState.Remove("NameQ5");
                        ModelState.Remove("EmailQ5");
                        ModelState.Remove("PhoneNumQ5");
                    }
                    if (!ModelState.IsValid)
                    {
                        return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/Apply.cshtml", model);
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
                    return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/Apply.cshtml", model);
                }

                string pdfLTAITemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LTA_I_AppFinal.pdf";
                string pdfLTAIITemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/LTA_II_AppFinal.pdf";
                string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

                try
                {
                    if (model.IsLTAI == true && model.IsLTAII == false)
                    {
                        _examService.FillLTAIExam(model, pdfLTAITemplate, newFile);
                    }
                    else if (model.IsLTAII == true)
                    {
                        _examService.FillLTAIIExam(model, pdfLTAIITemplate, newFile);
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("FillFormError", "error");
                }

                try
                {
                    _emailService.SendLTAExamEmail(newFile, model);

                    if (System.IO.File.Exists(HostingEnvironment.MapPath(newFile)))
                    {
                        System.IO.File.Delete(HostingEnvironment.MapPath(newFile));
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("EmailError", "error");
                }

                ModelState.Clear();
                return RedirectToAction("success", "LibraryTechnicalAssistant");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "error");
            }
        }
    }
}