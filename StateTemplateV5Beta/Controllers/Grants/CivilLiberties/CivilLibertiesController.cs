using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants/civil-liberties")]
    public class CivilLibertiesController : Controller
    {
        // GET: CivilLiberties
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/CivilLiberties/CivilLiberties.cshtml");
        }

        // GET: about
        [Route("about")]
        public ActionResult About()
        {
            return View("~/Views/Grants/CivilLiberties/About.cshtml");
        }

        // GET: contacts
        [Route("contacts")]
        public ActionResult Contacts()
        {
            return View("~/Views/Grants/CivilLiberties/Contacts.cshtml");
        }

        // GET: dates
        [Route("dates")]
        public ActionResult Dates()
        {
            return View("~/Views/Grants/CivilLiberties/Dates.cshtml");
        }

        // GET: recipients
        [Route("recipients")]
        public ActionResult Recipients()
        {
            return View("~/Views/Grants/CivilLiberties/Recipients.cshtml");
        }

    }
}