using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.GovernmentPublications.GovernmentPublications.StateDocumentDepositoryProgram
{
    [RoutePrefix("government-publications/state-document-depository-program")]
    public class StateDocumentDepositoryProgramController : Controller
    {
        // GET: StateDocumentDepositoryProgram
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/GovernmentPublications/StateDocumentDepositoryProgram/StateDocumentDepositoryProgram.cshtml");
        }

        // GET: depositories
        [Route("depositories")]
        public ActionResult Depositories()
        {
            return View("~/Views/GovernmentPublications/StateDocumentDepositoryProgram/Depositories.cshtml");
        }

        // GET: policies
        [Route("policies")]
        public ActionResult Policies()
        {
            return View("~/Views/GovernmentPublications/StateDocumentDepositoryProgram/Policies.cshtml");
        }
    }
}