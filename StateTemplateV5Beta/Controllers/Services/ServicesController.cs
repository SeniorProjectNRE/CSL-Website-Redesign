using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Services
{
    [RoutePrefix("Services")]
    public class ServicesController : Controller
    {
        // GET: Services
        [Route("")]
        public ActionResult Index()
        {
            return View("Services");
        }

        // GET: AdditionalResources
        [Route("Additional-Resources")]
        public ActionResult AdditionalResources()
        {
            return View();
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View();
        }

        // GET: Borrowing
        [Route("Borrowing")]
        public ActionResult Borrowing()
        {
            return View();
        }

        // GET: OnlineResources
        [Route("Online-Resources")]
        public ActionResult OnlineResources()
        {
            return View();
        }

        // GET: Policies
        [Route("Policies")]
        public ActionResult Policies()
        {
            return View();
        }

        // GET: Research
        [Route("Research")]
        public ActionResult Research()
        {
            return View();
        }

        // GET: To-Public
        [Route("To-Public")]
        public ActionResult ToPublic()
        {
            return View();
        }


        // GET: Interlibrary-Lending
        [Route("Interlibrary-Lending")]
        public ActionResult InterlibraryLending()
        {
            return View("~/Views/Services/InterlibraryLending.cshtml");
        }

        // GET: To-Public/Local-Libraries
        [Route("to-public/local-libraries")]
        public ActionResult ToPublicLocalLibraries()
        {
            return View("~/Views/Services/ToPublic/LocalLibraries.cshtml");
        }
    }
}