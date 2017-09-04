using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.ToLibraries.CALibraryServicesAct.Board
{
    [RoutePrefix("services/to-libraries/ca-library-services-act/board")]
    public class BoardController : Controller
    {
        // GET: Board
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/Board/Board.cshtml");
        }

        // GET: Meetings
        [Route("Meetings")]
        public ActionResult Meetings()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/Board/Meetings.cshtml");
        }

        // GET: Members
        [Route("Members")]
        public ActionResult Members()
        {
            return View("~/Views/Services/ToLibraries/CALibraryServicesAct/Board/Members.cshtml");
        }
    }
}