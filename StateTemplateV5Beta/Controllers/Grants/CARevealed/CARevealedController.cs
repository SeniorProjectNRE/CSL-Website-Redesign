﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants.LSTA.CARevealed
{
    [RoutePrefix("grants/ca-revealed")]
    public class CARevealedController : Controller
    {
        // GET: CARevealed
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Grants/CARevealed/CARevealed.cshtml");
        }

        // GET: fair-use
        [Route("fair-use")]
        public ActionResult FairUse()
        {
            return View("~/Views/Grants/CARevealed/FairUse.cshtml");
        }

        // GET: legal-consideration
        [Route("legal-consideration")]
        public ActionResult LegalConsideration()
        {
            return View("~/Views/Grants/CARevealed/LegalConsideration.cshtml");
        }

        // GET: local-govt-records
        [Route("local-govt-records")]
        public ActionResult LocalGovtRecords()
        {
            return View("~/Views/Grants/CARevealed/LocalGovtRecords.cshtml");
        }

        // GET: oral-histories
        [Route("oral-histories")]
        public ActionResult OralHistories()
        {
            return View("~/Views/Grants/CARevealed/OralHistories.cshtml");
        }

        // GET: orphan-works
        [Route("orphan-works")]
        public ActionResult OrphanWorks()
        {
            return View("~/Views/Grants/CARevealed/OrphanWorks.cshtml");
        }

        // GET: ownership
        [Route("ownership")]
        public ActionResult Ownership()
        {
            return View("~/Views/Grants/CARevealed/Ownership.cshtml");
        }

        // GET: permission
        [Route("permission")]
        public ActionResult Permission()
        {
            return View("~/Views/Grants/CARevealed/Permission.cshtml");
        }

        // GET: risk-management
        [Route("risk-management")]
        public ActionResult RiskManagement()
        {
            return View("~/Views/Grants/CARevealed/RiskManagement.cshtml");
        }
    }
}