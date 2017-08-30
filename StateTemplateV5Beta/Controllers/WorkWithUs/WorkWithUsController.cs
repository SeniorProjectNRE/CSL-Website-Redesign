using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("work-with-us")]
    public class WorkWithUsController : Controller
    {
        // GET: WorkWithUs
        [Route("")]
        public ActionResult Index()
        {
            return View("WorkWithUs");
        }   


        // GET: volunteer
        [Route("volunteer")]
        public ActionResult Volunteer()
        {
            return View();
        }
    }
}