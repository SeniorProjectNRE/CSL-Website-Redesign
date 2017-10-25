using CSLBusinessObjects.ViewModels;
using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface ILibraryService
    {
        List<LibraryAssemblyModel> GetAssembly(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryCityModel> GetCity(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryCLSAModel> GetCLSA(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryCongressionalModel> GetCongress(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryCountyModel> GetCounty(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryJurisdictionModel> GetJurisdiction(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryLibraryModel> GetLibrary(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibrarySenateModel> GetSenate(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryCodeModel> GetCode(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryStatusModel> GetStatus(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryZipModel> GetZip(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<LibraryModel> GetAllBroadband(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code);
        List<string> GetAssemblyListValues(List<LibraryAssemblyModel> model);
        List<string> GetCityListValues(List<LibraryCityModel> model);
        List<string> GetCLSAListValues(List<LibraryCLSAModel> model);
        List<string> GetCongressListValues(List<LibraryCongressionalModel> model);
        List<string> GetCountyListValues(List<LibraryCountyModel> model);
        List<string> GetJurisdictionListValues(List<LibraryJurisdictionModel> model);
        List<string> GetLibraryListValues(List<LibraryLibraryModel> model);
        List<string> GetSenateListValues(List<LibrarySenateModel> model);
        List<string> GetCodeListValues(List<LibraryCodeModel> model);
        List<string> GetStatusListValues(List<LibraryStatusModel> model);
        List<string> GetZipListValues(List<LibraryZipModel> model);
    }
}
