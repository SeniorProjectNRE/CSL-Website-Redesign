using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("About")]
    public class AboutController : Controller
    {
        // GET: About
        [Route("")]
        public ActionResult Index()
        {
            return View("About");
        }

        [Route("Executive-Staff")]
        public ActionResult ExecutiveStaff()
        {
            return View();
        }

        [Route("Library-Sections")]
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

        [Route("Press-Releases")]
        public ActionResult PressReleases()
        {
            return View();
        }

        [Route("test")]
        public ActionResult Test()
        {
            return View();
        }
    }
}