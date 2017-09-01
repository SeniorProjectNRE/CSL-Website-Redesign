using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.CaliforniaHistory
{
    [RoutePrefix("california-history/genealogy")]
    public class GenealogyController : Controller
    {
        // GET: Genealogy
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/CaliforniaHistory/Genealogy/Genealogy.cshtml");
        }

        // GET: county-indexes
        [Route("county-indexes")]
        public ActionResult CountyIndexes()
        {
            return View("~/Views/CaliforniaHistory/Genealogy/CountyIndexes.cshtml");
        }
    }
}