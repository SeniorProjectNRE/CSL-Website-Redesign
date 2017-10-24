using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants.LSTA
{
    [RoutePrefix("services/to-libraries/broadband")]
    public class BroadbandController : Controller
    {
        // GET: Broadband
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/Broadband/Broadband.cshtml");
        }

        // GET: libraries
        [Route("libraries")]
        public ActionResult Libraries()
        {
            return View("~/Views/Services/ToLibraries/Broadband/Libraries.cshtml");
        }

        
    }
}