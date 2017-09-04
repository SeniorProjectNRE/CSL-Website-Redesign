using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("Library-Development-Services")]
    public class LibraryDevServicesController : Controller
    {
        // GET: LibraryDevServices
        [Route("")]
        public ActionResult Index()
        {
            return View("LibraryDevelopmentServices");
        }
    }
}