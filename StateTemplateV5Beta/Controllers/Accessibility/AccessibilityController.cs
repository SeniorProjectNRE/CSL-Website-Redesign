using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Accessibility
{
    [RoutePrefix("Accessibility")]
    public class AccessibilityController : Controller
    {
        // GET: Accessibility
        [Route("")]
        public ActionResult Index()
        {
            return View("Accessibility");
        }
    }
}