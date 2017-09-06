using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        public String HomeImage
        {
            get
            {
                ViewBag.HomeImage = "~/Content/StateTemplate/images/home/Yosemite.jpg";
                return ViewBag.HomeImage;
            }
                           
        }
    }
}