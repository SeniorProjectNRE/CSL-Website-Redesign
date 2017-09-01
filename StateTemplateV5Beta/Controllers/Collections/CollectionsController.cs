using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Collections
{
    [RoutePrefix("collections")]
    public class CollectionsController : Controller
    {
        // GET: Collections
        [Route("")]
        public ActionResult Index()
        {
            return View("Collections");
        }

        // GET: Genealogy
        [Route("genealogy")]
        public ActionResult Genealogy()
        {
            return View("Genealogy");
        }
    }
}