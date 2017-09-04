using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Use
{
    [RoutePrefix("Use")]
    public class UseController : Controller
    {
        // GET: Use
        [Route("")]
        public ActionResult Index()
        {
            return View("Use");
        }
    }
}