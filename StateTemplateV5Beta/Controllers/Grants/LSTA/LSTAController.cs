using CSLBusinessLayer.Interface;
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
        [HttpGet]
        [Route("previous-grant-awards")]
        public ActionResult PreviousGrantAwards()
        {
            string grantID = null;
            string year = null;
            string library = null;
            string project = null;
            int award = 0;

            List<GrantsModel> AllList = _grantsService.GetAllGrants(grantID, year, library, project, award);
            List<GrantAwardModel> AwardList = _grantsService.GetAllAwards(grantID, year, library, project, award);
            List<GrantLibraryModel> LibraryList = _grantsService.GetAllLibraries(grantID, year, library, project, award);
            List<GrantNumberModel> NumberList = _grantsService.GetAllGrantIDs(grantID, year, library, project, award);
            List<GrantProjectModel> ProjectList = _grantsService.GetAllProjects(grantID, year, library, project, award);
            List<GrantYearModel> YearList = _grantsService.GetAllYears(grantID, year, library, project, award);
            List<String> NumListValues = _grantsService.GetNumListValues(NumberList);
            List<int> AwardListValues = _grantsService.GetAwardListValues(AwardList);
            List<String> ProjectListValues = _grantsService.GetProjectListValues(ProjectList);
            List<String> LibraryListValues = _grantsService.GetLibrariesListValues(LibraryList);
            List<String> YearListValues = _grantsService.GetYearListValues(YearList);

            GrantsViewModel viewModel = new GrantsViewModel()
            {
                GrantGetAllList = AllList,
                GrantAwardList = AwardList,
                GrantLibraryList = LibraryList,
                GrantNumberList = NumberList,
                GrantProjectList = ProjectList,
                GrantYearList = YearList,
                GetNumListValues = NumListValues,
                GetAwardListValues = AwardListValues,
                GetLibrariesListValues = LibraryListValues,
                GetProjectListValues = ProjectListValues,
                GetYearListValues = YearListValues
            };

            return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", viewModel);
        }

        // Post
        [HttpPost]
        [Route("previous-grant-awards")]
        public ActionResult PreviousGrantAwards(GrantsViewModel model)
        {
            //decimal principle = Convert.ToDecimal(Request["txtAmount"].ToString());
            string selectedGrantId;
            string selectedYear;
            string selectedLibrary;
            string selectedProject;
            int selectedAward;
            string grantID = null;
            string year = null;
            string library = null;
            string project = null;
            int award = 0;

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!ModelState.IsValid)
            {   
                return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", model);
            }

            if (model.GetNumListValues[0] == "All")
            {
                selectedGrantId = null;
            }
            else selectedGrantId = model.GetNumListValues[0];

            if (model.GetYearListValues[0] == "All")
            {
                selectedYear = null;
            }
            else selectedYear = model.GetYearListValues[0];

            if (model.GetLibrariesListValues[0] == "All")
            {
                selectedLibrary = null;
            }
            else selectedLibrary = model.GetLibrariesListValues[0];

            if (model.GetProjectListValues[0] == "All")
            {
                selectedProject = null;
            }
            else selectedProject = model.GetProjectListValues[0];

            if (model.GetAwardListValues[0] == 0)
            {
                selectedAward = 0;
            }
            else selectedAward = model.GetAwardListValues[0];

            List<GrantsModel> AllList = _grantsService.GetAllGrants(selectedGrantId, selectedYear, selectedLibrary, selectedProject, selectedAward);
            List<GrantAwardModel> AwardList = _grantsService.GetAllAwards(grantID, year, library, project, award);
            List<GrantLibraryModel> LibraryList = _grantsService.GetAllLibraries(grantID, year, library, project, award);
            List<GrantNumberModel> NumberList = _grantsService.GetAllGrantIDs(grantID, year, library, project, award);
            List<GrantProjectModel> ProjectList = _grantsService.GetAllProjects(grantID, year, library, project, award);
            List<GrantYearModel> YearList = _grantsService.GetAllYears(grantID, year, library, project, award);
            List<String> NumListValues = _grantsService.GetNumListValues(NumberList);
            List<int> AwardListValues = _grantsService.GetAwardListValues(AwardList);
            List<String> ProjectListValues = _grantsService.GetProjectListValues(ProjectList);
            List<String> LibraryListValues = _grantsService.GetLibrariesListValues(LibraryList);
            List<String> YearListValues = _grantsService.GetYearListValues(YearList);

            GrantsViewModel viewModel = new GrantsViewModel()
            {
                GrantGetAllList = AllList,
                GrantAwardList = AwardList,
                GrantLibraryList = LibraryList,
                GrantNumberList = NumberList,
                GrantProjectList = ProjectList,
                GrantYearList = YearList,
                GetNumListValues = NumListValues,
                GetAwardListValues = AwardListValues,
                GetLibrariesListValues = LibraryListValues,
                GetProjectListValues = ProjectListValues,
                GetYearListValues = YearListValues
            };

            return View("~/Views/Grants/LSTA/PreviousGrantAwards.cshtml", viewModel);
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