using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Services.ResearchResources
{
    [RoutePrefix("Services/Research-Resources")]
    public class ResearchResourcesController : Controller
    {
        // GET: ResearchResources
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ResearchResources/ResearchResources.cshtml");
        }

        // GET: AdditionalResources
        [Route("Additional-Resources")]
        public ActionResult AdditionalResources()
        {
            return View("~/Views/Services/ResearchResources/AdditionalResources.cshtml");
        }

        // GET: Patents
        [Route("Patents")]
        public ActionResult Patents()
        {
            return View("~/Views/Services/ResearchResources/Patents.cshtml");
        }

        // GET: Reference
        [Route("Reference")]
        public ActionResult Reference()
        {
            return View("~/Views/Services/ResearchResources/Reference.cshtml");
        }
    }
}