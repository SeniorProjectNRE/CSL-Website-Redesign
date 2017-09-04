using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.SiteMap
{
    [RoutePrefix("SiteMap")]
    public class SiteMapController : Controller
    {
        // GET: SiteMap
        [Route("")]
        public ActionResult Index()
        {
            return View("SiteMap");
        }
    }
}