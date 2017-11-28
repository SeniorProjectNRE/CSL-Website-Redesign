using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Collections
{
    [RoutePrefix("collections")]
    public class CollectionsController : Controller
    {
        // GET: Collections
        [Route("")]
        public ActionResult Index()
        {
            return View("Collections");
        }

        // GET: Genealogy
        [Route("genealogy")]
        public ActionResult Genealogy()
        {
            return View("~/Views/Collections/Genealogy/Genealogy.cshtml");
        }

        // GET: Genealogy
        [Route("genealogy/links")]
        public ActionResult Links()
        {
            return View("~/Views/Collections/Genealogy/Links.cshtml");
        }

        // GET: Genealogy
        [Route("genealogy/toolkit")]
        public ActionResult Toolkit()
        {
            return View("~/Views/Collections/Genealogy/Toolkit.cshtml");
        }

        // GET: OnlineCollections
        [Route("online-collections")]
        public ActionResult OnlineCollections()
        {
            return View("OnlineCollections");
        }


        // GET: VideoPodcasts
        [Route("videos-podcasts")]
        public ActionResult VideosPodcasts()
        {
            return View("VideosPodcasts");
        }
    }
}