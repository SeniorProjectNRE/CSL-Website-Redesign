using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.BTBL
{
    [RoutePrefix("BTBL")]
    public class BTBLController : Controller
    {
        // GET: BTBL
        [Route("")]
        public ActionResult Index()
        {
            return View("BTBL");
        }

        // GET: advisory-council
        [Route("advisory-council")]
        public ActionResult AdvisoryCouncil()
        {
            return View();
        }

        // GET: bard
        [Route("bard")]
        public ActionResult Bard()
        {
            return View();
        }

        // GET: advisory-council
       /* [Route("advisory-council")]
        public ActionResult AdvisoryCouncil()
        {
            return View();
        }*/

        // GET: borrow
        [Route("borrow")]
        public ActionResult Borrow()
        {
            return View();
        }

        // GET: contact
        [Route("contact")]
        public ActionResult Contact()
        {
            return View();
        }

        // GET: descriptive-video-service
        [Route("descriptive-video-service")]
        public ActionResult DescriptiveVideoService()
        {
            return View();
        }

        // GET: donations
        [Route("donations")]
        public ActionResult Donations()
        {
            return View();
        }

        // GET: handbook
        [Route("handbook")]
        public ActionResult Handbook()
        {
            return View();
        }

        // GET: newsletter
        [Route("newsletter")]
        public ActionResult Newsletter()
        {
            return View();
        }

        // GET: policies
        [Route("policies")]
        public ActionResult Policies()
        {
            return View();
        }

        // GET: print-disabilities
        [Route("print-disabilities")]
        public ActionResult PrintDisabilities()
        {
            return View();
        }

        // GET: publications
        [Route("publications")]
        public ActionResult Publications()
        {
            return View();
        }

        // GET: purchase-book
        [Route("purchase-book")]
        public ActionResult PurchaseBook()
        {
            return View();
        }

        // GET: purchase-player
        [Route("purchase-player")]
        public ActionResult PurchasePlayer()
        {
            return View();
        }

        // GET: ravenous-readers
        [Route("ravenous-readers")]
        public ActionResult RavenousReaders()
        {
            return View();
        }

        // GET: resources
        [Route("resources")]
        public ActionResult Resources()
        {
            return View();
        }

        // GET: service
        [Route("service")]
        public ActionResult Service()
        {
            return View();
        }

        // GET: summer-reading
        [Route("summer-reading")]
        public ActionResult SummerReading()
        {
            return View();
        }

        // GET: bookshare
        [Route("bookshare")]
        public ActionResult Bookshare()
        {
            return View();
        }

        // GET: apply
        [Route("apply")]
        public ActionResult Apply()
        {
            return View();
        }

        // GET: purchase-cartridge
        [Route("purchase-cartridge")]
        public ActionResult PurchaseCartridge()
        {
            return View();
        }

    }
}