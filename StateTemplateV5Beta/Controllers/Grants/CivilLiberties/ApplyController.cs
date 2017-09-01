using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants/civil-liberties/apply")]
    public class ApplyController : Controller
    {
        // GET: Apply
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/CivilLiberties/Apply/Apply.cshtml");
        }

        // GET: application
        [Route("application")]
        public ActionResult Application()
        {
            return View("~/Views/Grants/CivilLiberties/Apply/Application.cshtml");
        }
    }
}