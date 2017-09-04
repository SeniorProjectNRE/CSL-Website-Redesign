using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.ToStateEmployees
{
    [RoutePrefix("Services/To-State-Employees")]
    public class ToStateEmployeesController : Controller
    {
        // GET: ToStateEmployees
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToStateEmployees/ToStateEmployees.cshtml");
        }

        // GET: State-Training-Videos
        [Route("State-Training-Videos")]
        public ActionResult StateTrainingVideos()
        {
            return View("~/Views/Services/ToStateEmployees/StateTrainingVideos.cshtml");
        }
    }
}