using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    [RoutePrefix("art")]
    public class ArtController : Controller
    {
        // GET: Art
        [Route("")]
        public ActionResult Index()
        {
            return View("Art");
        }
    }
}