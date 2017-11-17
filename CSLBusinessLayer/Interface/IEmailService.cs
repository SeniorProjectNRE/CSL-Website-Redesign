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
        bool SendLibrarianExamEmail(string file, LibrarianModel model);
    }
}
