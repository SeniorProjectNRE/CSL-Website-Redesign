using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.VisitUs
{
    [RoutePrefix("visit-us")]
    public class VisitUsController : Controller
    {
        // GET: VisitUs
        [Route("")]
        public ActionResult Index()
        {
            return View("VisitUs");
        }

        // GET: Events
        [Route("Events")]
        public ActionResult Events()
        {
            return View();
        }

        // GET: Exhibits
        [Route("Exhibits")]
        public ActionResult Exhibits()
        {
            return View();
        }

        // GET: Locations-And-Hours
        [Route("Locations-And-Hours")]
        public ActionResult LocationsAndHours()
        {
            return View();
        }

        // GET: Tours
        [Route("Tours")]
        public ActionResult Tours()
        {
            return View();
        }
    }
}