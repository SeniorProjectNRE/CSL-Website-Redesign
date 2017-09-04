using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("Mailing-Lists")]
    public class MailingListsController : Controller
    {
        // GET: MailingLists
        [Route("")]
        public ActionResult Index()
        {
            return View("MailingLists");
        }
    }
}