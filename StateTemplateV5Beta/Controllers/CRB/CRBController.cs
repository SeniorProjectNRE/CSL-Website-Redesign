using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.CRB
{
    [RoutePrefix("crb")]
    public class CRBController : Controller
    {
        // GET: CRB
        [Route("")]
        public ActionResult Index()
        {
            return View("CRB");
        }

        // GET: frivolous-action
        [Route("frivolous-action")]
        public ActionResult FrivolousAction()
        {
            return View("");
        }

        // GET: newsletters
        [Route("newsletters")]
        public ActionResult Newsletters()
        {
            return View("");
        }

        // GET: reports-events
        [Route("reports-events")]
        public ActionResult ReportsEvents()
        {
            return View("");
        }

        // GET: staff
        [Route("staff")]
        public ActionResult Staff()
        {
            return View("");
        }
    }
}