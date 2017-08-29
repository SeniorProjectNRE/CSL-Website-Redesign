using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.About
{
    [RoutePrefix("About/History/State-Librarians")]
    public class StateLibrariansController : Controller
    {
        // GET: StateLibrarians
        [Route("")]
        public ActionResult Index()
        {
            return View("StateLibrarians");
        }

        [Route("Aldrich")]
        public ActionResult Aldrich()
        {
            return View();
        }

        [Route("Hildreth")]
        public ActionResult Hildreth()
        {
            return View();
        }

        [Route("Lucas")]
        public ActionResult Lucas()
        {
            return View();
        }
    }
}