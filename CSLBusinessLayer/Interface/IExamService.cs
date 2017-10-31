﻿using CSLBusinessObjects.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface IExamService
    {
        string FillForm(LibrarianModel model, string pdfTemplate, string newFile);
    }
}
