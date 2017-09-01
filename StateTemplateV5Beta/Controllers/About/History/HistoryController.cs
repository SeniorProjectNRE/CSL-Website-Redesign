using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("About/History")]
    public class HistoryController : Controller
    {
        // GET: History
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/About/History/History.cshtml");
        }

        [Route("building")]
        public ActionResult Building()
        {
            return View("~/Views/About/History/Building.cshtml");
        }
    }
}