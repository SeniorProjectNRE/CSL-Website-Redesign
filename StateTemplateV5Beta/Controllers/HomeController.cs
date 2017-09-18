using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateTemplateV5Beta.Models;
using StateTemplateV5Beta.Models.HelperClasses;

namespace StateTemplateV5Beta.Controllers
{
    
    public class HomeController : Controller
    {
        //private CSLDataModel db = new CSLDataModel();

        public ActionResult Index()
        {
            //var topThree = (from t in db.AddBlogs
            //                orderby t.BlogID descending
            //                select t).Take(3);
            //HomeViewModel homeModel = new HomeViewModel()
            //{
            //    BlogList = topThree               
            //};
            
            return View(/*homeModel*/);
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

        [Route("releases")]
        public ActionResult Releases()
        {
            return View();
        }

    }
}