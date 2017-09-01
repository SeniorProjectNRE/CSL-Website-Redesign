using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Collections
{
    [RoutePrefix("collections/online-exhibits")]
    public class OnlineExhibitsController : Controller
    {
        // GET: OnlineExhibits
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Collections/OnlineExhibits/OnlineExhibits.cshtml");
        }

        // GET: Hayden
        [Route("hayden")]
        public ActionResult Hayden()
        {
            return View("~/Views/Collections/OnlineExhibits/Hayden.cshtml");
        }

    }
}