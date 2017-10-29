using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface IEmailService
    {
        SuccessModel SendSutroClassEmail(SutroClassModel model);
    }
}
