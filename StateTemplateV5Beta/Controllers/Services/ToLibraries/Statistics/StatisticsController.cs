using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Services.ToLibraries.Statistics
{
    [RoutePrefix("Services/To-Libraries/Statistics")]
    public class StatisticsController : Controller
    {
        // GET: Statistics
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/Statistics/Statistics.cshtml");
        }

        // GET: Summary
        [Route("Summary")]
        public ActionResult Summary()
        {
            return View("~/Views/Services/ToLibraries/Statistics/Summary.cshtml");
        }
    }
}