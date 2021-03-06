﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Error
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("")]
        public ActionResult Index()
        {
            return View("Error");
        }

        // GET: Error
        [Route("EmailError")]
        public ActionResult EmailError()
        {
            return View();
        }

        // GET: Error
        [Route("FormError")]
        public ActionResult FillFormError()
        {
            return View();
        }
    }
}