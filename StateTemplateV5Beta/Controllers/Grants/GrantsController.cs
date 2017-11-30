using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants")]
    public class GrantsController : Controller
    {

        private IGrantsService _grantsService;

        public GrantsController()
        {

        }

        public GrantsController(IGrantsService grantsService)
        {
            _grantsService = grantsService;
        }

        // GET: Grants
        [Route("")]
        public ActionResult Index()
        {
            return View("Grants");
        }

        // GET: LSTA
        [Route("lsta")]
        public ActionResult LSTA()
        {
            return View();
        }

        // GET: apply
        [Route("apply")]
        public ActionResult Apply()
        {
            return View();
        }

        // GET: career-online-high-school
        [Route("career-online-high-school")]
        public ActionResult CareerOnlineHighSchool()
        {
            return View();
        }

        // GET: harwood
        [Route("harwood")]
        public ActionResult Harwood()
        {
            return View();
        }

        // GET: immigrant-alliance
        [Route("immigrant-alliance")]
        public ActionResult ImmigrantAlliance()
        {
            return View();
        }

        // GET: initatives
        [Route("initatives")]
        public ActionResult Initatives()
        {
            return View();
        }

        // GET: libraries-illuminated
        [Route("libraries-illuminated")]
        public ActionResult LibrariesIlluminated()
        {
            return View();
        }

        // GET:manage
        //[Route("manage")]
        //public ActionResult Manage()
        //{
        //    return View();
        //}

        // GET: mental-health
        [Route("mental-health")]
        public ActionResult MentalHealth()
        {
            return View();
        }

        // GET: pitch-an-idea
        [Route("pitch-an-idea")]
        public ActionResult PitchAnIdea()
        {
            return View();
        }

        // GET: staff-innovation
        [Route("staff-innovation")]
        public ActionResult StaffInnovation()
        {
            return View();
        }

        // GET: statewide
        [Route("statewide")]
        public ActionResult Statewide()
        {
            return View();
        }

        // GET: virtual-reality
        [Route("virtual-reality")]
        public ActionResult VirtualReality()
        {
            return View();
        }

        // GET: innovation-station
        [Route("innovation-station")]
        public ActionResult InnovationStation()
        {
            return View();
        }

        // GET: /library-services-technology-act
        //[Route("library-services-technology-act")]
        //public ActionResult LibraryServicesTechnologyAct()
        //{
        //    return View();
        //}
    }
}