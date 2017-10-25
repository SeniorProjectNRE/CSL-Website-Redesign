using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateTemplateV5Beta.Controllers.Grants.LSTA
{
    [RoutePrefix("services/to-libraries/broadband")]
    public class BroadbandController : Controller
    {
        private ILibraryService _libraryService;

        public BroadbandController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Broadband
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/Services/ToLibraries/Broadband/Broadband.cshtml");
        }

        // GET: libraries
        [HttpGet]
        [Route("libraries")]
        public ActionResult Libraries()
        {
            string library = null, jurisdiction = null, csla = null, city = null, county = null, status = null, code = null;
            int zip = 0, assembly = 0, senate = 0, congress = 0;
            LibraryViewModel model = LibraryModelBuilder(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            return View("~/Views/Services/ToLibraries/Broadband/Libraries.cshtml", model);
        }

        // POST: libraries
        [HttpPost]
        [Route("libraries")]
        public ActionResult Libraries(LibraryViewModel model)
        {
            return View("~/Views/Services/ToLibraries/Broadband/Libraries.cshtml", model);
        }

        private LibraryViewModel LibraryModelBuilder(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            LibraryViewModel res;

            List<LibraryAssemblyModel> GetAssemblyList = _libraryService.GetAssembly(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCityModel> GetCityList = _libraryService.GetCity(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCLSAModel> GetCLSAList = _libraryService.GetCLSA(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCodeModel> GetCodeList = _libraryService.GetCode(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCongressionalModel> GetCongressionalList = _libraryService.GetCongress(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryCountyModel> GetCountyList = _libraryService.GetCounty(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryJurisdictionModel> GetJurisdictionList = _libraryService.GetJurisdiction(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryLibraryModel> GetLibraryList = _libraryService.GetLibrary(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibrarySenateModel> GetSenateList = _libraryService.GetSenate(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryStatusModel> GetStatusList = _libraryService.GetStatus(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryZipModel> GetZipList = _libraryService.GetZip(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            List<LibraryModel> GetAllLibraries = _libraryService.GetAllBroadband(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);

            List<string> GetCityListValues = _libraryService.GetCityListValues(GetCityList);
            List<string> GetLibraryListValues = _libraryService.GetLibraryListValues(GetLibraryList);
            List<string> GetJurisdictionListValues = _libraryService.GetJurisdictionListValues(GetJurisdictionList);
            List<string> GetCLSAListValues = _libraryService.GetCLSAListValues(GetCLSAList);
            List<string> GetCountyListValues = _libraryService.GetCountyListValues(GetCountyList);
            List<string> GetStatusListValues = _libraryService.GetStatusListValues(GetStatusList);
            List<string> GetCodeListValues = _libraryService.GetCodeListValues(GetCodeList);
            List<int> GetZipListValues = _libraryService.GetZipListValues(GetZipList);
            List<int> GetAssemblyListValues = _libraryService.GetAssemblyListValues(GetAssemblyList);
            List<int> GetSenateListValues = _libraryService.GetSenateListValues(GetSenateList);
            List<int> GetCongressionalListValues = _libraryService.GetCongressListValues(GetCongressionalList);

            res = new LibraryViewModel()
            {
                GetAssemblyList = GetAssemblyList,
                GetCityList = GetCityList,
                GetCLSAList = GetCLSAList,
                GetCodeList = GetCodeList,
                GetCongressionalList = GetCongressionalList,
                GetCountyList = GetCountyList,
                GetJurisdictionList = GetJurisdictionList,
                GetLibraryList = GetLibraryList,
                GetSenateList = GetSenateList,
                GetStatusList = GetStatusList,
                GetZipList = GetZipList,
                GetAllLibraries = GetAllLibraries,
                GetCityListValues = GetCityListValues,
                GetLibraryListValues = GetLibraryListValues,
                GetJurisdictionListValues = GetJurisdictionListValues,
                GetAssemblyListValues = GetAssemblyListValues,
                GetCLSAListValues = GetCLSAListValues,
                GetCodeListValues = GetCodeListValues,
                GetCongressionalListValues = GetCongressionalListValues,
                GetCountyListValues = GetCountyListValues,
                GetSenateListValues = GetSenateListValues,
                GetStatusListValues = GetStatusListValues,
                GetZipListValues = GetZipListValues
            };

            return res;
        }
    

    }
}