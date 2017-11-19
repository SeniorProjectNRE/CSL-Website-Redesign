using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants.LibraryServicesTechnologyAct
{
    [RoutePrefix("grants/library-services-technology-act")]
    public class LibraryServicesTechnologyActController : Controller
    {
        // GET: LibraryServicesTechnologyAct
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/LibraryServicesTechnologyAct.cshtml");
        }

        // GET: manage
        [Route("manage")]
        public ActionResult Manage()
        {
            return View("~/Views/Grants/LibraryServicesTechnologyAct/Manage.cshtml");
        }
    }
}