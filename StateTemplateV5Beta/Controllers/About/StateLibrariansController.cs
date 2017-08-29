using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.About
{
    public class StateLibrariansController : Controller
    {
        // GET: StateLibrarians
        public ActionResult Index()
        {
            return View("StateLibrarians");
        }

        public ActionResult Aldrich()
        {
            return View();
        }

        public ActionResult Hildreth()
        {
            return View();
        }

        public ActionResult Lucas()
        {
            return View();
        }
    }
}