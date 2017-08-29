using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("about")]
    public class AboutController : Controller
    {
        // GET: About
        [Route("")]
        public ActionResult Index()
        {
            return View("About");
        }

        [Route("History")]
        public ActionResult History()
        {
            return View();
        }

        [Route("History/Building")]
        public ActionResult Building()
        {
            return View();
        }


        [Route("ExecutiveStaff")]
        public ActionResult ExecutiveStaff()
        {
            return View();
        }

        [Route("LibrarySections")]
        public ActionResult LibrarySections()
        {
            return View();
        }

        [Route("Mission")]
        public ActionResult Mission()
        {
            return View();
        }

        [Route("Multimedia")]
        public ActionResult Multimedia()
        {
            return View();
        }

        [Route("PressReleases")]
        public ActionResult PressReleases()
        {
            return View();
        }
    }
}