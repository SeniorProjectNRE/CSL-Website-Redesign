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

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.SupervisingLibrarian
{
    [RoutePrefix("work-with-us/jobs/Supervising-Librarian")]
    public class SupervisingLibrarianController : Controller
    {
        private IExamService _examService;
        private IEmailService _emailService;

        public SupervisingLibrarianController(IEmailService emailService, IExamService examService)
        {
            _emailService = emailService;
            _examService = examService;
        }

        // GET: SupervisingLibrarian
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/jobs/SupervisingLibrarian/SupervisingLibrarian.cshtml");
        }

        [Route("success")]
        // GET: success
        public ActionResult Success()
        {
            return View("~/Views/WorkWithUs/Jobs/SupervisingLibrarian/Success.cshtml");
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            SupervisingLibrarianModel model = new SupervisingLibrarianModel();
            return View("~/Views/WorkWithUs/Jobs/SupervisingLibrarian/Apply.cshtml",model);
        }

        [HttpPost]
        [Route("apply")]
        public ActionResult Apply(SupervisingLibrarianModel model, HttpPostedFileBase file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (model.IsSupervisingLibrarianI == true && model.IsSupervisingLibrarianII == false && model.IsPrincipalLibrarian == false)
                    {
                        ModelState.Remove("Q9");
                        ModelState.Remove("NameQ9");
                        ModelState.Remove("EmailQ9");
                        ModelState.Remove("PhoneNumQ9");
                        ModelState.Remove("Q10");
                        ModelState.Remove("NameQ10");
                        ModelState.Remove("EmailQ10");
                        ModelState.Remove("PhoneNumQ10");
                        ModelState.Remove("Q11");
                        ModelState.Remove("NameQ11");
                        ModelState.Remove("EmailQ11");
                        ModelState.Remove("PhoneNumQ11");
                        ModelState.Remove("Q12");
                        ModelState.Remove("NameQ12");
                        ModelState.Remove("EmailQ12");
                        ModelState.Remove("PhoneNumQ12");
                    }
                    if (model.IsSupervisingLibrarianI == false && model.IsSupervisingLibrarianII == true && model.IsPrincipalLibrarian == false)
                    {
                        ModelState.Remove("Q11");
                        ModelState.Remove("NameQ11");
                        ModelState.Remove("EmailQ11");
                        ModelState.Remove("PhoneNumQ11");
                        ModelState.Remove("Q12");
                        ModelState.Remove("NameQ12");
                        ModelState.Remove("EmailQ12");
                        ModelState.Remove("PhoneNumQ12");
                    }
                    if (!ModelState.IsValid)
                    {
                        return View("~/Views/WorkWithUs/Jobs/SupervisingLibrarian/Apply.cshtml", model);
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
                    return View("~/Views/WorkWithUs/Jobs/SupervisingLibrarian/Apply.cshtml", model);
                }

                string pdfSupervisingLibrarianITemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/SL1AppFinal.pdf";
                string pdfSupervisingLibrarianIITemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/SL2AppFinal.pdf";
                string pdfPrincipalLibrarianTemplate = "~/Content/StateTemplate/pdf/ExamPDFTemplates/PLAppFinal.pdf";
                string newFile = "~/Content/StateTemplate/pdf/ExamPDFTemplates/" + model.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pdf";

                if (model.IsSupervisingLibrarianI = true && model.IsSupervisingLibrarianII == false && model.IsPrincipalLibrarian == false)
                {
                    _examService.FillSupervisingLibrarianIExam(model, pdfSupervisingLibrarianITemplate, newFile);
                }
                else if (model.IsSupervisingLibrarianII == true && model.IsPrincipalLibrarian == false)
                {
                    _examService.FillSupervisingLibrarianIIExam(model, pdfSupervisingLibrarianIITemplate, newFile);
                } else _examService.FillPrincipalLibrarianExam(model, pdfPrincipalLibrarianTemplate, newFile);

                bool res = _emailService.SendSupervisingLibrarianExamEmail(newFile, model);

                if (System.IO.File.Exists(HostingEnvironment.MapPath(newFile)))
                {
                    System.IO.File.Delete(HostingEnvironment.MapPath(newFile));
                }

                ModelState.Clear();
                model.Success = res;
                return RedirectToAction("success", "SupervisingLibrarian");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "error");
            }
        }
    }
}