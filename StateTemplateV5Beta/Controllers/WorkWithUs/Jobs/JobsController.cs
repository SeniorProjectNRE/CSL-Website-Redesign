using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs
{
    [RoutePrefix("work-with-us/jobs")]
    public class JobsController : Controller
    {
        // GET: Jobs
        [Route("")]
        public ActionResult Index()
        {
            return View("Jobs");
        }
    }
}