using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.ToLibraries.CALibraryServicesAct
{
    [RoutePrefix("services/to-libraries/ca-library-services-act")]
    public class CALibraryServicesActController : Controller
    {
        // GET: CALibraryServicesAct
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/CALibraryServicesAct.cshtml");
        }

        // GET: About
        [Route("About")]
        public ActionResult About()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/About.cshtml");
        }

        // GET: Systems
        [Route("Systems")]
        public ActionResult Systems()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/Systems.cshtml");
        }
    }
}