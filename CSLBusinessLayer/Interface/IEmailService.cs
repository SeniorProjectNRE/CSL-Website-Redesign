using CSLBusinessObjects.Models;
using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessLayer.Interface
{
    public interface IEmailService
    {
        bool SendSutroClassEmail(SutroClassModel model);
        void SendLibrarianExamEmail(string file, LibrarianModel model);
        bool SendSupervisingLibrarianExamEmail(string file, SupervisingLibrarianModel model);
        bool SendLPAExamEmail(string newFile, LPAModel model);
        bool SendLPCExamEmail(string newFile, LPCModel model);
        bool SendLTAExamEmail(string newFile, LTAModel model);
    }
}
