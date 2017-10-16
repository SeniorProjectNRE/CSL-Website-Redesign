using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Sutro
{
    [RoutePrefix("sutro")]
    public class SutroController : Controller
    {
        // GET: Sutro
        [Route("")]
        public ActionResult Index()
        {
            return View("Sutro");
        }

        // GET: adolph-sutro
        [Route("adolph-sutro")]
        public ActionResult AdolphSutro()
        {
            return View();
        }

        // GET: class
        [Route("class")]
        public ActionResult Class()
        {
            return View();
        }

        // GET: collection
        [Route("collection")]
        public ActionResult Collection()
        {
            return View();
        }

        // GET: coloring-book
        [Route("coloring-book")]
        public ActionResult ColoringBook()
        {
            return View();
        }

        // GET: genealogy
        [Route("genealogy")]
        public ActionResult Genealogy()
        {
            return View();
        }

        // GET: search
        [Route("search")]
        public ActionResult Search()
        {
            return View();
        }

        // GET: visiting
        [Route("visiting")]
        public ActionResult Visiting()
        {
            return View();
        }

        // GET: womens-march
        [Route("womens-march")]
        public ActionResult WomensMarch()
        {
            return View();
        }

        // GET: genealogy/calendar
        [Route("genealogy/calendar")]
        public ActionResult Calendar()
        {
            return View("~/Views/Sutro/Genealogy/Calendar.cshtml");
        }
    }
}