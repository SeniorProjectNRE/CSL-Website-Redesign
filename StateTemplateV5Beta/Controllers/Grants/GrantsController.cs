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
        [Route("manage")]
        public ActionResult Manage()
        {
            return View();
        }

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
            List<String> AwardListNumbers = _grantsService.AwardStrings();

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
                GetYearListValues = YearListValues,
                AwardStrings = AwardListNumbers
            };

            return View(viewModel);
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
                return View(model);
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

            if (model.AwardStrings[0] == "All")
            {
                selectedAward = 0;
            }
            else selectedAward = _grantsService.GetAwardCategoryFromString(model.AwardStrings[0]);

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
            List<String> AwardListNumbers = _grantsService.AwardStrings();

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
                GetYearListValues = YearListValues,
                AwardStrings = AwardListNumbers
            };

            return View(viewModel);
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
        [Route("library-services-technology-act")]
        public ActionResult LibraryServicesTechnologyAct()
        {
            return View();
        }
    }
}