using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Concrete
{
    public class ExamService
    {
        public string FillForm(string pdfTemplate , string newFile)
        {
            string res = null;
            try
            {
                using (PdfReader pdfReader = new PdfReader(pdfTemplate))
                {
                    using (FileStream pdfFileStream = new FileStream(newFile, FileMode.Create))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, pdfFileStream))
                        {
                            AcroFields pdfFormFields = pdfStamper.AcroFields;

                            //set pdf form fields
                            //basic info
                            //pdfFormFields.SetField("Name", )

                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
            return res;
        }
    }
}
