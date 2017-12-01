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
        [Route("database")]
        public ActionResult Libraries()
        {
            string library = null, jurisdiction = null, csla = null, city = null, county = null, status = null, code = null;
            int zip = 0, assembly = 0, senate = 0, congress = 0;
            LibraryViewModel model = LibraryModelBuilder(library, jurisdiction, csla, city, county, zip, assembly, senate, congress, status, code);
            return View("~/Views/Services/ToLibraries/Broadband/Libraries.cshtml", model);
        }

        // POST: libraries
        [HttpPost]
        [Route("database")]
        public ActionResult Libraries(LibraryViewModel model)
        {
            string selectedLibrary, selectedJurisdiction, selectedCsla, selectedCity, selectedCounty, selectedStatus, selectedCode;
            int selectedZip, selectedAssembly, selectedSenate, selectedCongress;

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.GetStatusListValues[0] == "All")
            {
                selectedStatus = null;
            }
            else selectedStatus = model.GetStatusListValues[0].ToString();

            if (model.GetCodeListValues[0] == "All")
            {
                selectedCode = null;
            }
            else selectedCode = model.GetCodeListValues[0].ToString();

            if (model.GetCountyListValues[0] == "All")
            {
                selectedCounty = null;
            }
            else selectedCounty = model.GetCountyListValues[0].ToString();

            if (model.GetCityListValues[0] == "All")
            {
                selectedCity = null;
            }
            else selectedCity = model.GetCityListValues[0].ToString();

            if (model.GetCLSAListValues[0] == "All")
            {
                selectedCsla = null;
            }
            else selectedCsla = model.GetCLSAListValues[0].ToString();

            if (model.GetJurisdictionListValues[0] == "All")
            {
                selectedJurisdiction = null;
            }
            else selectedJurisdiction = model.GetJurisdictionListValues[0].ToString();

            if (model.GetLibraryListValues[0] == "All")
            {
                selectedLibrary = null;
            }
            else selectedLibrary = model.GetLibraryListValues[0].ToString();

            if (model.GetAssemblyListValues[0] == "All")
            {
                selectedAssembly = 0;
            }
            else selectedAssembly = Convert.ToInt32(model.GetAssemblyListValues[0]);

            if (model.GetZipListValues[0] == "All")
            {
                selectedZip = 0;
            }
            else selectedZip = Convert.ToInt32(model.GetZipListValues[0]);

            if (model.GetSenateListValues[0] == "All")
            {
                selectedSenate = 0;
            }
            else selectedSenate = Convert.ToInt32(model.GetSenateListValues[0]);

            if (model.GetCongressionalListValues[0] == "All")
            {
                selectedCongress = 0;
            }
            else selectedCongress = Convert.ToInt32(model.GetCongressionalListValues[0]);

            LibraryViewModel viewModel = LibraryModelBuilder(selectedLibrary, selectedJurisdiction, selectedCsla, selectedCity, selectedCounty, selectedZip, selectedAssembly, selectedSenate, selectedCongress, selectedStatus, selectedCode);

            return View("~/Views/Services/ToLibraries/Broadband/Libraries.cshtml", viewModel);
        }

        private LibraryViewModel LibraryModelBuilder(string selectedLibrary, string selectedJurisdiction, string selectedCsla, string selectedCity, string selectedCounty, int selectedZip, int selectedAssembly, int selectedSenate, int selectedCongress, string selectedStatus, string selectedCode)
        {
            LibraryViewModel res;

            string library = null, jurisdiction = null, csla = null, city = null, county = null, status = null, code = null;
            int zip = 0, assembly = 0, senate = 0, congress = 0;

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
            List<LibraryModel> GetAllLibraries = _libraryService.GetAllBroadband(selectedLibrary, selectedJurisdiction, selectedCsla, selectedCity, selectedCounty, selectedZip, selectedAssembly, selectedSenate, selectedCongress, selectedStatus, selectedCode);

            List<string> GetCityListValues = _libraryService.GetCityListValues(GetCityList);
            List<string> GetLibraryListValues = _libraryService.GetLibraryListValues(GetLibraryList);
            List<string> GetJurisdictionListValues = _libraryService.GetJurisdictionListValues(GetJurisdictionList);
            List<string> GetCLSAListValues = _libraryService.GetCLSAListValues(GetCLSAList);
            List<string> GetCountyListValues = _libraryService.GetCountyListValues(GetCountyList);
            List<string> GetStatusListValues = _libraryService.GetStatusListValues(GetStatusList);
            List<string> GetCodeListValues = _libraryService.GetCodeListValues(GetCodeList);
            List<string> GetZipListValues = _libraryService.GetZipListValues(GetZipList);
            List<string> GetAssemblyListValues = _libraryService.GetAssemblyListValues(GetAssemblyList);
            List<string> GetSenateListValues = _libraryService.GetSenateListValues(GetSenateList);
            List<string> GetCongressionalListValues = _libraryService.GetCongressListValues(GetCongressionalList);

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