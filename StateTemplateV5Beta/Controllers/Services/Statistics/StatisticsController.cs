using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Services.Statistics
{
    [RoutePrefix("Services/Statistics")]
    public class StatisticsController : Controller
    {
        // GET: Statistics
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/Statistics/Statistics.cshtml");
        }

        // GET: Archive
        [Route("Archive")]
        public ActionResult Archive()
        {
            return View("~/Views/Services/Statistics/Archive.cshtml");
        }

        // GET: Library-Directory
        [Route("Library-Directory")]
        public ActionResult LibraryDirectory()
        {
            return View("~/Views/Services/Statistics/LibraryDirectory.cshtml");
        }

        // GET: Summary
        [Route("Summary")]
        public ActionResult Summary()
        {
            return View("~/Views/Services/Statistics/Summary.cshtml");
        }
    }
}