﻿using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants
{
    [RoutePrefix("grants/lsta")]
    public class LSTAController : Controller
    {
        private IGrantsService _grantsService;

        public LSTAController()
        {

        }

        public LSTAController(IGrantsService grantsService)
        {
            _grantsService = grantsService;
        }

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
            GrantsModel grants = new GrantsModel { GrantID = "40-7600", Year = "2010/2011", Library = "Alameda County Library", Project = "Ashland READS", Award = 4 };
            List < GrantsModel > grantList = new List<GrantsModel>();
            grantList.Add(grants);
            GrantsViewModel viewModel = new GrantsViewModel() { GrantGetAllList = grantList };

            return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", viewModel);
        }

        // Post
        [HttpPost]
        public ActionResult PreviousGrantAwards(GrantsViewModel model)
        {
            //decimal principle = Convert.ToDecimal(Request["txtAmount"].ToString());
            string grantID = "40-7600";
            string year = "2010/2011";
            string library = "Alameda County Library";
            string project = "Ashland READS";
            int award = 4;

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!ModelState.IsValid)
            {
                
                return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", model);
            }

            model = _grantsService.GetAllGrants(grantID, year, library, project, award);

            List<GrantsModel> grantModel = model.GrantGetAllList;

            return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", grantModel);
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