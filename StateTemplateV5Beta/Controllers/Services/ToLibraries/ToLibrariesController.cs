using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.ToLibraries
{
    [RoutePrefix("Services/To-Libraries")]
    public class ToLibrariesController : Controller
    {
        // GET: ToLibraries
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/ToLibraries.cshtml");
        }

        // GET: E-Rate
        [Route("E-Rate")]
        public ActionResult ERate()
        {
            return View("~/Views/Services/ToLibraries/ERate.cshtml");
        }

        // GET: Grants
        [Route("Grants")]
        public ActionResult Grants()
        {
            return View("~/Views/Services/ToLibraries/Grants.cshtml");
        }

        // GET: Interlibrary-Lending
        [Route("Interlibrary-Lending")]
        public ActionResult InterlibraryLending()
        {
            return View("~/Views/Services/ToLibraries/InterlibraryLending.cshtml");
        }
    }
}