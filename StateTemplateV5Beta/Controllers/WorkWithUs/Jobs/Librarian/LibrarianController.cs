using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.WorkWithUs.Jobs.Librarian
{
    [RoutePrefix("work-with-us/jobs/librarian")]
    public class LibrarianController : Controller
    {
        [Route("")]
        // GET: Librarian
        public ActionResult Index()
        {
            return View("Librarian");
        }

        [Route("apply")]
        public ActionResult Apply()
        {
            return View();
        }
    }
}