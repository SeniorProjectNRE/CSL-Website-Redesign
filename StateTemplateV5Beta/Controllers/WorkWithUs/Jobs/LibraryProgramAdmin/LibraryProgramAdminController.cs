using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.LibraryProgramAdmin
{
    [RoutePrefix("work-with-us/jobs/Library-Program-Admin")]
    public class LibraryProgramAdminController : Controller
    {
        [Route("")]
        // GET: LibraryProgramAdmin
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/LibraryProgramAdmin.cshtml");
        }

        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramAdmin/Apply.cshtml");
        }
    }
}