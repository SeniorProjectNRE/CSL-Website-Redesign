using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.GovernmentPublications
{
    [RoutePrefix("government-publications")]
    public class GovernmentPublicationsController : Controller
    {
        // GET: GovernmentPublications
        [Route("")]
        public ActionResult Index()
        {
            return View("GovernmentPublications");
        }

        // GET: SLAA
        [Route("slaa")]
        public ActionResult SLAA()
        {
            return View();
        }

        // GET: state-document-depositories
        [Route("state-document-depositories")]
        public ActionResult StateDocumentDepositories()
        {
            return View();
        }

        // GET: state-document-depository-program
        [Route("state-document-depository-program")]
        public ActionResult StateDocumentDepositoryProgram()
        {
            return View();
        }
    }
}