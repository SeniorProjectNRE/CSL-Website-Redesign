using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Law
{
    [RoutePrefix("Law")]
    public class LawController : Controller
    {
        // GET: Law
        [Route("")]
        public ActionResult Index()
        {
            return View("Law");
        }
    }
}