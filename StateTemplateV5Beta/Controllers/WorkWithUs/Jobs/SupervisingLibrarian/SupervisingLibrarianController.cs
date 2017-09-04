using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.SupervisingLibrarian
{
    [RoutePrefix("work-with-us/jobs/Supervising-Librarian")]
    public class SupervisingLibrarianController : Controller
    {
        // GET: SupervisingLibrarian
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/jobs/SupervisingLibrarian/SupervisingLibrarian.cshtml");
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/SupervisingLibrarian/Apply.cshtml");
        }
    }
}