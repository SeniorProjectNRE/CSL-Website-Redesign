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
    }
}