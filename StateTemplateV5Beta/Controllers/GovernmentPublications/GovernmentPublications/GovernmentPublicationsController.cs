using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.GovernmentPublications
{
    [RoutePrefix("government-publications")]
    public class GovernmentPublicationsController : Controller
    {
        private ISLAAService _slaaService;

        public GovernmentPublicationsController(ISLAAService slaaService)
        {
            _slaaService = slaaService;
        }

        // GET: GovernmentPublications
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/GovernmentPublications/GovernmentPublications.cshtml");
        }

        // GET: Publications
        [Route("ca-publications")]
        public ActionResult CAPublications()
        {
            return View("~/Views/GovernmentPublications/CAPublications.cshtml");
        }

        // GET: SLAA
        [HttpGet]
        [Route("slaa")]
        public ActionResult SLAA()
        {
            int year = 0;
            string agencyCode = null;

            SLAAViewModel viewModel = SLAAModelBuilder(year, agencyCode);
            return View("~/Views/GovernmentPublications/SLAA.cshtml", viewModel);
        }

        // Postback: SLAA
        [HttpPost]
        [Route("slaa")]
        public ActionResult SLAA(SLAAViewModel viewModel)
        {
            string selectedAgency;
            int selectedYear;

            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/GovernmentPublications/SLAA.cshtml", viewModel);
            }

            if (viewModel.GetYearListValues[0] == "All")
            {
                selectedYear = 0;
            }
            else selectedYear = Convert.ToInt32(viewModel.GetYearListValues[0]);

            if (viewModel.GetAgencyListValues[0] == "All")
            {
                selectedAgency = null;
            }
            else selectedAgency = _slaaService.GetAgencyCodeFromAgencyName(viewModel.GetAgencyListValues[0].ToString());

            viewModel = SLAAModelBuilder(selectedYear, selectedAgency);

            return View("~/Views/GovernmentPublications/SLAA.cshtml", viewModel);
        }

        // GET: state-document-depositories
        [Route("state-document-depositories")]
        public ActionResult StateDocumentDepositories()
        {
            return View("~/Views/GovernmentPublications/StateDocumentDepositories.cshtml");
        }

        private SLAAViewModel SLAAModelBuilder(int selectedYear, string selectedAgency)
        {
            SLAAViewModel res;

            int year = 0;
            string agency = null;

            List<SLAAAgencyModel> GetAgencyList = _slaaService.GetAllAgencyCode(year, agency);
            List<SLAAYearModel> GetYearList = _slaaService.GetAllYear(year, agency);
            List<SLAAModel> GetAllSLAAList = _slaaService.GetAllSLAA(selectedYear, selectedAgency);

            List<string> GetAllAgencyListValues = _slaaService.GetAgencyCodeListValues(GetAgencyList);
            List<string> GetAllYearListValues = _slaaService.GetYearListValues(GetYearList);

            res = new SLAAViewModel()
            {
                GetAgencyListValues = GetAllAgencyListValues,
                GetYearListValues = GetAllYearListValues,
                SLAAGetAllFromTableList = GetAllSLAAList
            };

            return res;

        }
    }
}