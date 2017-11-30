using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.ToLibraries
{
    [RoutePrefix("Services/To-Libraries")]
    public class ToLibrariesController : Controller
    {
        // GET: ToLibraries
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/ToLibraries.cshtml");
        }

        // GET: E-Rate
        [Route("E-Rate")]
        public ActionResult ERate()
        {
            return View("~/Views/Services/ToLibraries/ERate.cshtml");
        }

        // GET: Grants
        [Route("Grants")]
        public ActionResult Grants()
        {
            return View("~/Views/Services/ToLibraries/Grants.cshtml");
        }

        // GET: development-programs-projects
        [Route("development-programs-projects")]
        public ActionResult DevelopmentProgramsProjects()
        {
            return View("~/Views/Services/ToLibraries/DevelopmentProgramsProjects/DevelopmentProgramsProjects.cshtml");
        }

        // GET: development-programs-projects/value-libraries
        [Route("development-programs-projects/value-libraries")]
        public ActionResult ValueLibraries()
        {
            return View("~/Views/Services/ToLibraries/DevelopmentProgramsProjects/ValueLibraries.cshtml");
        }
        
        // GET: erate
        [Route("broadband-erate")]
        public ActionResult BroadbandERate()
        {
            return View("~/Views/Services/ToLibraries/BroadbandERate.cshtml");
        }

        // GET: ImmigrantAlliance
        [Route("immigrant-alliance")]
        public ActionResult ImmigrantAlliance()
        {
            return View("~/Views/Services/ToLibraries/ImmigrantAlliance.cshtml");
        }

        // GET: harwood
        [Route("harwood")]
        public ActionResult Harwood()
        {
            return View("~/Views/Services/ToLibraries/Harwood.cshtml");
        }

        // GET: innovation-station
        [Route("innovation-station")]
        public ActionResult InnovationStation()
        {
            return View("~/Views/Services/ToLibraries/InnovationStation.cshtml");
        }

        // GET: libraries-illuminated
        [Route("libraries-illuminated")]
        public ActionResult LibrariesIlluminated()
        {
            return View("~/Views/Services/ToLibraries/LibrariesIlluminated.cshtml");
        }

        // GET: LibraryDirectory
        [Route("library-directory")]
        public ActionResult LibraryDirectory()
        {
            return View("~/Views/Services/ToLibraries/LibraryDirectory.cshtml");
        }

        // GET: LibraryLaws
        [Route("library-laws")]
        public ActionResult LibraryLaws()
        {
            return View("~/Views/Services/ToLibraries/LibraryLaws.cshtml");
        }

        // GET: zip-books
        [Route("zip-books")]
        public ActionResult ZipBooks()
        {
            return View("~/Views/Services/ToLibraries/ZipBooks.cshtml");
        }

        // GET: library-staff-education-program
        [Route("public-library-staff-education-program")]
        public ActionResult LibraryStaffEducationProgram()
        {
            return View("~/Views/Services/ToLibraries/LibraryStaffEducationPogram.cshtml");
        }

        // GET: statistics-directories
        [Route("statistics-directories")]
        public ActionResult StatisticsDirectories()
        {
            return View("~/Views/Services/ToLibraries/StatisticsDirectories.cshtml");
        }

        // GET: laws-public-library-organization
        [Route("laws-public-library-organization")]
        public ActionResult LawsPublicLibraryOrganization()
        {
            return View("~/Views/Services/ToLibraries/LawsPublicLibraryOrganization.cshtml");
        }

        // GET: cooperative-systems-clsa
        [Route("cooperative-systems-clsa")]
        public ActionResult CooperativeSystemsClsa()
        {
            return View("~/Views/Services/ToLibraries/CooperativeSystemsClsa.cshtml");
        }

        // GET: career-online-high-school
        [Route("career-online-high-school")]
        public ActionResult CareerOnlineHighSchool()
        {
            return View("~/Views/Services/ToLibraries/CareerOnlineHighSchool.cshtml");
        }

    }
}