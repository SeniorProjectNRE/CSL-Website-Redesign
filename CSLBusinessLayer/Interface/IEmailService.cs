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
        SuccessModel SendSutroClassEmail(SutroClassModel model);
        SuccessModel SendLibrarianExamEmail(string file, LibrarianModel model);
    }
}
