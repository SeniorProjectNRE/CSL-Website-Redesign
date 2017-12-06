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
        void FillLibrarianExam(LibrarianModel model, string pdfTemplate, string newFile);
        void FillForm(LibrarianModel model, string pdfTemplate, string newFile);
        void FillSeniorLibrarianExam(LibrarianModel model, string pdfSeniorLibrarianTemplate, string newFile);
        void FillSupervisingLibrarianIExam(SupervisingLibrarianModel model, string pdfSupervisingLibrarianITemplate, string newFile);
        void FillSupervisingLibrarianIIExam(SupervisingLibrarianModel model, string pdfSupervisingLibrarianIITemplate, string newFile);
        void FillPrincipalLibrarianExam(SupervisingLibrarianModel model, string pdfPrincipalLibrarianTemplate, string newFile);
        void FillLPAExam(LPAModel model, string pdfLPAtemplate, string newFile);
        void FillLPCExam(LPCModel model, string pdfLPAtemplate, string newFile);
        void FillLTAIExam(LTAModel model, string pdfLTAITemplate, string newFile);
        void FillLTAIIExam(LTAModel model, string pdfLTAIITemplate, string newFile);
    }
}
