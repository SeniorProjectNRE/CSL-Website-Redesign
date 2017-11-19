using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface IExamService
    {
        bool FillLibrarianExam(LibrarianModel model, string pdfTemplate, string newFile);
        bool FillForm(LibrarianModel model, string pdfTemplate, string newFile);
        bool FillSeniorLibrarianExam(LibrarianModel model, string pdfSeniorLibrarianTemplate, string newFile);
        bool FillSupervisingLibrarianIExam(SupervisingLibrarianModel model, string pdfSupervisingLibrarianITemplate, string newFile);
        bool FillSupervisingLibrarianIIExam(SupervisingLibrarianModel model, string pdfSupervisingLibrarianIITemplate, string newFile);
        bool FillPrincipalLibrarianExam(SupervisingLibrarianModel model, string pdfPrincipalLibrarianTemplate, string newFile);
        bool FillLPAExam(LPAModel model, string pdfLPAtemplate, string newFile);
    }
}
