using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessObjects.ViewModels
{
    public class LibraryViewModel
    {
        public List<LibraryAssemblyModel> GetAssemblyList { get; set; }
        public List<LibraryCityModel> GetCityList { get; set; }
        public List<LibraryCLSAModel> GetCLSAList { get; set; }
        public List<LibraryCodeModel> GetCodeList { get; set; }
        public List<LibraryCongressionalModel> GetCongressionalList { get; set; }
        public List<LibraryCountyModel> GetCountyList { get; set; }
        public List<LibraryJurisdictionModel> GetJurisdictionList { get; set; }
        public List<LibraryLibraryModel> GetLibraryList { get; set; }
        public List<LibrarySenateModel> GetSenateList { get; set; }
        public List<LibraryStatusModel> GetStatusList { get; set; }
        public List<LibraryZipModel> GetZipList { get; set; }
        public List<LibraryModel> GetAllLibraries { get; set; }
        public int SelectedAssembly { get; set; }
        public string SelectedCity{ get; set; }
        public string SelectedCLSA { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedCounty{ get; set; }
        public string SelectedJurisdiction { get; set; }
        public string SelectedLibrary { get; set; }
        public string SelectedStatus { get; set; }
        public int SelectedZip { get; set; }
        public int SelectedCongressional { get; set; }
        public int SelectedSenate { get; set; }
    }
}
