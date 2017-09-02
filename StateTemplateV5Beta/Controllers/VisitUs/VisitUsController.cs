using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.VisitUs
{
    [RoutePrefix("visit-us")]
    public class VisitUsController : Controller
    {
        // GET: VisitUs
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}