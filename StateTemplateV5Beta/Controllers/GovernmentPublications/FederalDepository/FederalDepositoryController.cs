using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.GovernmentPublications
{
    [RoutePrefix("government-publications/federal-depository")]
    public class FederalDepositoryController : Controller
    {
        // GET: FederalDepository
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/GovernmentPublications/FederalDepository/FederalDepository.cshtml");
        }

        // GET: disposal-instructions
        [Route("disposal-instructions")]
        public ActionResult DisposalInstructions()
        {
            return View("~/Views/GovernmentPublications/FederalDepository/DisposalInstructions.cshtml");
        }

        // GET: disposal-list
        [Route("disposal-list")]
        public ActionResult DisposalList()
        {
            return View("~/Views/GovernmentPublications/FederalDepository/DisposalList.cshtml");
        }

        // GET: performance-standards
        [Route("performance-standards")]
        public ActionResult PerformanceStandards()
        {
            return View("~/Views/GovernmentPublications/FederalDepository/PerformanceStandards.cshtml");
        }
    }
}