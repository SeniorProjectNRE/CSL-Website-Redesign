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
        public string FillLibrarianExam(LibrarianModel model, string pdfTemplate, string newFile)
        {
            string res = null;
            try
            {
                using (PdfReader pdfReader = new PdfReader(System.IO.File.ReadAllBytes(HostingEnvironment.MapPath(pdfTemplate))))
                {
                    using (FileStream pdfFileStream = new FileStream(HostingEnvironment.MapPath(newFile), FileMode.Create))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, pdfFileStream))
                        {
                            AcroFields pdfFormFields = pdfStamper.AcroFields;

                            //set pdf form fields
                            //basic info
                            #region BasicInfo
                            pdfFormFields.SetField("Name", model.Name);
                            pdfFormFields.SetField("Email", model.Email);
                            pdfFormFields.SetField("Education", model.HasEducation.ToString());

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }
                            if (model.IfNot == true)
                            {
                                pdfFormFields.SetField("EduReg", "On");
                            }

                            //Search Experience
                            pdfFormFields.SetField("SearchExp", model.SearchStrategies);
                            pdfFormFields.SetField("SearchContact", model.NameSearchStrategies);
                            pdfFormFields.SetField("SearchEmail", model.EmailSearchStrategies);
                            pdfFormFields.SetField("SearchPhone", model.PhoneNumSearchStrategies);

                            //Bibliographic Experience
                            pdfFormFields.SetField("BibliographicExp", model.BibliographicInfo);
                            pdfFormFields.SetField("BibliographicContact", model.NameBibliographicInfo);
                            pdfFormFields.SetField("BibliographicEmail", model.EmailBibliographicInfo);
                            pdfFormFields.SetField("BibliographicPhone", model.PhoneNumBibliographicInfo);

                            //Database Experience
                            pdfFormFields.SetField("DatabaseExp", model.ComputerizedData);
                            pdfFormFields.SetField("DatabaseContact", model.NameComputerizedData);
                            pdfFormFields.SetField("DatabaseEmail", model.EmailComputerizedData);
                            pdfFormFields.SetField("DatabasePhone", model.PhoneNumComputerizedData);
                            #endregion

                            #region Questions
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);


                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);
#endregion 

                            if(model.isCertified == true)
                            {
                                pdfFormFields.SetField("SigChkBox", "On");
                            }
                            pdfFormFields.SetField("Signature", model.Signature);
                            pdfFormFields.SetField("Date", model.Date);

                            pdfStamper.FormFlattening = true;
                            pdfStamper.Close();
                            pdfReader.Close();
                            pdfFileStream.Close();
                        }
                        pdfFileStream.Close();
                    }
                    pdfReader.Close();
                }
            }
            catch(Exception ex)
            {

            }
            return res;
        }

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
                            pdfFormFields.SetField("Email", model.Email);
                            pdfFormFields.SetField("Education", model.HasEducation.ToString());

                            //many more fields go here
                            //..
                            //..
                            //..

                            pdfStamper.FormFlattening = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }
}
