using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Privacy
{
    [RoutePrefix("Privacy")]
    public class PrivacyController : Controller
    {
        // GET: Privacy
        [Route("")]
        public ActionResult Index()
        {
            return View("Privacy");
        }
    }
}