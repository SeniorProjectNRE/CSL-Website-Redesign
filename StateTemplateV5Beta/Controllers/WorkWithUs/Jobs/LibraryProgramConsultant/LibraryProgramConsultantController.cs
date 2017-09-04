using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.LibraryProgramConsultant
{
    [RoutePrefix("work-with-us/jobs/Library-Program-Consultant")]
    public class LibraryProgramConsultantController : Controller
    {
        // GET: LibraryProgramConsultant
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramConsultant/LibraryProgramConsultant.cshtml");
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View("~/Views/WorkWithUs/Jobs/LibraryProgramConsultant/Apply.cshtml");
        }
    }
}