using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateTemplateV5Beta.Models;

namespace StateTemplateV5Beta.Controllers
{
    public class HomeController : Controller
    {
        private CSLDataModel db = new CSLDataModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blogs()
        {
            return View(db.AddBlogs);
        }

        public ActionResult serviceProfile()
        {
            return View("~/Views/Shared/modules/service-profile.cshtml");
        }

        public ActionResult serviceDirectory()
        {
            return View("~/Views/Shared/modules/service-directory.cshtml");
        }
    
        public ActionResult serp()
        {
            return View("~/Views/Shared/modules/serp.cshtml");
        }

    }
}