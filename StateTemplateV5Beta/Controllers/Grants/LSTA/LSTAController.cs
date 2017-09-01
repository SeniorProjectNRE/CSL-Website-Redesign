using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants/lsta")]
    public class LSTAController : Controller
    {
        // GET: LSTA
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/LSTA/LSTA.cshtml");
        }

        // GET: apply
        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/Grants/LSTA/Apply.cshtml");
        }

        // GET: career-online-high-school
        [Route("career-online-high-school")]
        public ActionResult CareerOnlineHighSchool()
        {
            return View("~/Views/Grants/LSTA/CareerOnlineHighSchool.cshtml");
        }

        // GET: harwood
        [Route("harwood")]
        public ActionResult Harwood()
        {
            return View("~/Views/Grants/LSTA/Harwood.cshtml");
        }

        // GET: immigrant-alliance
        [Route("immigrant-alliance")]
        public ActionResult ImmigrantAlliance()
        {
            return View("~/Views/Grants/LSTA/ImmigrantAlliance.cshtml");
        }

        // GET: initatives
        [Route("initatives")]
        public ActionResult Initatives()
        {
            return View("~/Views/Grants/LSTA/Initatives.cshtml");
        }

        // GET: libraries-illuminated
        [Route("libraries-illuminated")]
        public ActionResult LibrariesIlluminated()
        {
            return View("~/Views/Grants/LSTA/LibrariesIlluminated.cshtml");
        }

        // GET:manage
        [Route("manage")]
        public ActionResult Manage()
        {
            return View("~/Views/Grants/LSTA/Manage.cshtml");
        }

        // GET: mental-health
        [Route("mental-health")]
        public ActionResult MentalHealth()
        {
            return View("~/Views/Grants/LSTA/MentalHealth.cshtml");
        }

        // GET: pitch-an-idea
        [Route("pitch-an-idea")]
        public ActionResult PitchAnIdea()
        {
            return View("~/Views/Grants/LSTA/PitchAnIdea.cshtml");
        }

        // GET: previous-grant-awards
        [Route("previous-grant-awards")]
        public ActionResult PreviousGrantAwards()
        {
            return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml");
        }

        // GET: staff-innovation
        [Route("staff-innovation")]
        public ActionResult StaffInnovation()
        {
            return View("~/Views/Grants/LSTA/StaffInnovation.cshtml");
        }

        // GET: statewide
        [Route("statewide")]
        public ActionResult Statewide()
        {
            return View("~/Views/Grants/LSTA/Statewide.cshtml");
        }

        // GET: virtual-reality
        [Route("virtual-reality")]
        public ActionResult VirtualReality()
        {
            return View("~/Views/Grants/LSTA/VirtualReality.cshtml");
        }
    }
}