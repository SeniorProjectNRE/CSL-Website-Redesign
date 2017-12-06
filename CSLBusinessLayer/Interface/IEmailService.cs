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
        void SendSutroClassEmail(SutroClassModel model);
        void SendLibrarianExamEmail(string file, LibrarianModel model);
        void SendSupervisingLibrarianExamEmail(string file, SupervisingLibrarianModel model);
        void SendLPAExamEmail(string newFile, LPAModel model);
        void SendLPCExamEmail(string newFile, LPCModel model);
        void SendLTAExamEmail(string newFile, LTAModel model);
    }
}
