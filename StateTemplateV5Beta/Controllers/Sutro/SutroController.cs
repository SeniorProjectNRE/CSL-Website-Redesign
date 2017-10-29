using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Sutro
{
    [RoutePrefix("sutro")]
    public class SutroController : Controller
    {
        private IEmailService _emailService;

        public SutroController()
        {

        }

        public SutroController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // GET: Sutro
        [Route("")]
        public ActionResult Index()
        {
            return View("Sutro");
        }

        // GET: adolph-sutro
        [Route("adolph-sutro")]
        public ActionResult AdolphSutro()
        {
            return View();
        }

        // GET: class
        [HttpGet]
        [Route("class")]
        public ActionResult Class()
        {
            //SutroClassModel model = new SutroClassModel() { SuccessMessage = null};
            return View();
        }

        // Post: class
        [HttpPost]
        [Route("class")]
        public ActionResult Class(SutroClassModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lf0XzYUAAAAAEHDxHcYouICuNOMph90Gc1XTOaT";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            model.IsCaptcha = status;

            if(model.IsCaptcha == false)
            {
                return View(model);
            }

            SuccessModel success = _emailService.SendSutroClassEmail(model);
            model.SuccessMessage = success.SuccessMessage;
            return View(model);
        }

        // GET: collection
        [Route("collection")]
        public ActionResult Collection()
        {
            return View();
        }

        // GET: coloring-book
        [Route("coloring-book")]
        public ActionResult ColoringBook()
        {
            return View();
        }

        // GET: genealogy
        [Route("genealogy")]
        public ActionResult Genealogy()
        {
            return View();
        }

        // GET: search
        [Route("search")]
        public ActionResult Search()
        {
            return View();
        }

        // GET: visiting
        [Route("visiting")]
        public ActionResult Visiting()
        {
            return View();
        }

        // GET: womens-march
        [Route("womens-march")]
        public ActionResult WomensMarch()
        {
            return View();
        }

        // GET: genealogy/calendar
        [Route("genealogy/calendar")]
        public ActionResult Calendar()
        {
            return View("~/Views/Sutro/Genealogy/Calendar.cshtml");
        }
    }
}