using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("contact")]
    public class ContactController : Controller
    {
        // GET: Contact
        [Route("")]
        public ActionResult Index()
        {
            return View("Contact");
        }
    }
}