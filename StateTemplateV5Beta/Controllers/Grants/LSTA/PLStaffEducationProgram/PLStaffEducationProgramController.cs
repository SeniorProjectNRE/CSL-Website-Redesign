using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants.LSTA.PLStaffEducationProgram
{
    [RoutePrefix("grants/lsta/public-library-staff-education-program")]
    public class PLStaffEducationProgramController : Controller
    {
        // GET: PLStaffEducationProgram
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/LSTA/PLStaffEducationProgram/PLStaffEducationProgram.cshtml");
        }

        // GET: apply
        [Route("apply")]
        public ActionResult Apply()
        {
            return View("~/Views/Grants/LSTA/PLStaffEducationProgram/Apply.cshtml");
        }
    }
}