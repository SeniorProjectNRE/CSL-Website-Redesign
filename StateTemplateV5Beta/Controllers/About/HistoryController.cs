using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.About
{
    [RoutePrefix("about/history")]
    public class HistoryController : Controller
    {
        // GET: History
        [Route("")]
        public ActionResult Index()
        {
            return View("History");
        }

        [Route("building")]
        public ActionResult Building()
        {
            return View("Building");
        }
    }
}