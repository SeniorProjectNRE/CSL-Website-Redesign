using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("california-history")]
    public class CaliforniaHistoryController : Controller
    {
        // GET: california-history
        [Route("")]
        public ActionResult Index()
        {
            return View("CaliforniaHistory");
        }

        // GET: books
        [Route("books")]
        public ActionResult Books()
        {
            return View();
        }

        // GET: cagoldrush
        [Route("cagoldrush")]
        public ActionResult CAGoldrush()
        {
            return View();
        }

        // GET: collections
        [Route("collections")]
        public ActionResult Collections()
        {
            return View();
        }

        // GET: county-month
        [Route("county-month")]
        public ActionResult CountyMonth()
        {
            return View();
        }

        // GET: databases
        [Route("databases")]
        public ActionResult Databases()
        {
            return View();
        }

        // GET: digital-images
        [Route("digital-images")]
        public ActionResult DigitalImages()
        {
            return View();
        }

        // GET: display
        [Route("current-display")]
        public ActionResult CurrentDisplay()
        {
            return View();
        }

        // GET: donations
        [Route("donations")]
        public ActionResult Donations()
        {
            return View();
        }

        // GET: digitized-resources
        [Route("digitized-resources")]
        public ActionResult DigitizedResources()
        {
            return View();
        }

        // GET: ephemera
        [Route("ephemera")]
        public ActionResult Ephemera()
        {
            return View();
        }

        // GET: events
        [Route("events")]
        public ActionResult Events()
        {
            return View();
        }

        // GET: gold-rush
        [Route("gold-rush")]
        public ActionResult GoldRush()
        {
            return View();
        }

        // GET: manuscripts
        [Route("manuscripts")]
        public ActionResult Manuscripts()
        {
            return View();
        }

        // GET: maps
        [Route("maps")]
        public ActionResult Maps()
        {
            return View();
        }

        // GET: newspapers
        [Route("newspapers")]
        public ActionResult Newspapers()
        {
            return View();
        }

        // GET: periodicals
        [Route("periodicals")]
        public ActionResult Periodicals()
        {
            return View();
        }

        // GET: periodicals-month
        [Route("periodicals-month")]
        public ActionResult PeriodicalsMonth()
        {
            return View();
        }

        // GET: permission-to-use
        [Route("permission-to-use")]
        public ActionResult PermissionToUse()
        {
            return View();
        }

        // GET: photocopy
        [Route("photocopy")]
        public ActionResult Photocopy()
        {
            return View();
        }

        // GET: Pictorial-Resources
        [Route("Pictorial-Resources")]
        public ActionResult PictorialResources()
        {
            return View();
        }

        // GET: previous-ca-capitals
        [Route("previous-ca-capitals")]
        public ActionResult PreviousCACapitals()
        {
            return View();
        }

        // GET: research-guides
        [Route("research-guides")]
        public ActionResult ResearchGuides()
        {
            return View();
        }

        // GET: state-symbols
        [Route("state-symbols")]
        public ActionResult StateSymbols()
        {
            return View();
        }

        // GET: unique-indexes
        [Route("unique-indexes")]
        public ActionResult UniqueIndexes()
        {
            return View();
        }

        // GET: visiting
        [Route("visiting")]
        public ActionResult Visiting()
        {
            return View();
        }

        // GET: fair-use
        [Route("fair-use")]
        public ActionResult FairUse()
        {
            return View();
        }

        // GET: photo-reproduction
        [Route("photo-reproduction")]
        public ActionResult PhotoReproduction()
        {
            return View();
        }
    }
}