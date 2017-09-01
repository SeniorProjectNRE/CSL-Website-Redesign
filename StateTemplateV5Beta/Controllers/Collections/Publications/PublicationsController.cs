using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Collections
{
    [RoutePrefix("collections/publications")]
    public class PublicationsController : Controller
    {
        // GET: Publications
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Collections/Publications/Publications.cshtml");
        }

        // GET: Publications
        [Route("ca-publications")]
        public ActionResult CAPublications()
        {
            return View("~/Views/Collections/Publications/CAPublications.cshtml");
        }

        // GET: Publications
        [Route("library-laws")]
        public ActionResult LibraryLaws()
        {
            return View("~/Views/Collections/Publications/LibraryLaws.cshtml");
        }
    }
}