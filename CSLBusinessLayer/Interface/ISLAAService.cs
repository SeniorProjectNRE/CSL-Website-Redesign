using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface ISLAAService
    {
        List<SLAAModel> GetAllSLAA(int year, string code);
        List<SLAAAgencyModel> GetAllAgencyCode(int year, string code);
        List<SLAAYearModel> GetAllYear(int year, string code);
        List<string> GetAgencyCodeListValues(List<SLAAAgencyModel> model);
        List<string> GetYearListValues(List<SLAAYearModel> model);
        string GetAgencyCodeFromAgencyName(string v);
    }
}
