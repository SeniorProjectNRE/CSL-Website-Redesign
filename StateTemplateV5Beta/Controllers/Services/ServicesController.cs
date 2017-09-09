﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Services
{
    [RoutePrefix("Services")]
    public class ServicesController : Controller
    {
        // GET: Services
        [Route("")]
        public ActionResult Index()
        {
            return View("Services");
        }

        // GET: Apply
        [Route("Apply")]
        public ActionResult Apply()
        {
            return View();
        }

        // GET: Borrowing
        [Route("Borrowing")]
        public ActionResult Borrowing()
        {
            return View();
        }

        // GET: OnlineResources
        [Route("Online-Resources")]
        public ActionResult OnlineResources()
        {
            return View();
        }

        // GET: Policies
        [Route("Policies")]
        public ActionResult Policies()
        {
            return View();
        }

        // GET: To-Public
        [Route("To-Public")]
        public ActionResult ToPublic()
        {
            return View();
        }
    }
}