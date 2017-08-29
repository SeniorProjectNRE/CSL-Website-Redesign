using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Apply
{
    [RoutePrefix("Apply")]
    public class ApplyController : Controller
    {
        // GET: Apply
        [Route("")]
        public ActionResult Index()
        {
            return View("Apply");
        }
    }
}