using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.LibraryTechnicalAssistant
{
    [RoutePrefix("work-with-us/jobs/Library-Technical-Assistant")]
    public class LibraryTechnicalAssistantController : Controller
    {
        // GET: LibraryTechnicalAssistant
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/LibraryTechnicalAssistant.cshtml");
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryTechnicalAssistant/Apply.cshtml");
        }
    }
}