using CSLBusinessLayer.Interface;
using CSLBusinessObjects.Models.Exams;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CSLBusinessLayer.Concrete
{
    public class ExamService : IExamService
    {
        public string FillForm(LibrarianModel model, string pdfTemplate, string newFile)
        {
            string res = null;
            try
            {
                using (PdfReader pdfReader = new PdfReader(HostingEnvironment.MapPath(pdfTemplate)))
                {
                    using (FileStream pdfFileStream = new FileStream(HostingEnvironment.MapPath(newFile), FileMode.Create))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, pdfFileStream))
                        {
                            AcroFields pdfFormFields = pdfStamper.AcroFields;

                            //set pdf form fields
                            //basic info
                            pdfFormFields.SetField("Name", model.Name);
                            pdfStamper.FormFlattening = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return res;
        }
    }
}
