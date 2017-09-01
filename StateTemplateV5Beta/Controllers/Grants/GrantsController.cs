using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants")]
    public class GrantsController : Controller
    {
        // GET: Grants
        [Route("")]
        public ActionResult Index()
        {
            return View("Grants");
        }
    }
}