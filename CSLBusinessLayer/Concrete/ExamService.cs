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
                            pdfFormFields.SetField("Name", model.Name);
                            pdfFormFields.SetField("Email", model.Email);
                            pdfFormFields.SetField("Education", model.HasEducation.ToString());

                            //If rblExperience.SelectedValue = 0 Then
                            //pdfFormFields.SetField("LPAOneYearExp", "On")
                            //End If
                            //If rblExperience.SelectedValue = 1 Then
                            //pdfFormFields.SetField("LPATwoYearExp", "On")
                            //End If
                            //If rblExperience.SelectedValue = 2 Then
                            //pdfFormFields.SetField("LPAFiveYearExp", "On")
                            //End If

                            //' Question 1
                            //If rblQ1.SelectedValue = 0 Then
                            //pdfFormFields.SetField("Q1None", "On")
                            //End If
                            //If rblQ1.SelectedValue = 1 Then
                            //pdfFormFields.SetField("Q1Limited", "On")
                            //End If
                            //If rblQ1.SelectedValue = 2 Then
                            //pdfFormFields.SetField("Q1Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            //    ' Question 2
                            //If rblQ2.SelectedValue = 0 Then
                            //    pdfFormFields.SetField("Q2None", "On")
                            //End If
                            //If rblQ2.SelectedValue = 1 Then
                            //    pdfFormFields.SetField("Q2Limited", "On")
                            //End If
                            //If rblQ2.SelectedValue = 2 Then
                            //    pdfFormFields.SetField("Q2Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            //' Question 3
                            //If rblQ3.SelectedValue = 0 Then
                            //    pdfFormFields.SetField("Q3None", "On")
                            //End If
                            //If rblQ3.SelectedValue = 1 Then
                            //    pdfFormFields.SetField("Q3Limited", "On")
                            //End If
                            //If rblQ3.SelectedValue = 2 Then
                            //    pdfFormFields.SetField("Q3Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                        //    ' Question 4
                        //If rblQ4.SelectedValue = 0 Then
                        //    pdfFormFields.SetField("Q4None", "On")
                        //End If
                        //If rblQ4.SelectedValue = 1 Then
                        //    pdfFormFields.SetField("Q4Limited", "On")
                        //End If
                        //If rblQ4.SelectedValue = 2 Then
                        //    pdfFormFields.SetField("Q4Considerable", "On")
                        //End If

                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            //    ' Question 5
                            //If rblQ5.SelectedValue = 0 Then
                            //    pdfFormFields.SetField("Q5None", "On")
                            //End If
                            //If rblQ5.SelectedValue = 1 Then
                            //    pdfFormFields.SetField("Q5Limited", "On")
                            //End If
                            //If rblQ5.SelectedValue = 2 Then
                            //    pdfFormFields.SetField("Q5Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            //    ' Question 6
                            //If rblQ6.SelectedValue = 0 Then
                            //    pdfFormFields.SetField("Q6None", "On")
                            //End If
                            //If rblQ6.SelectedValue = 1 Then
                            //    pdfFormFields.SetField("Q6Limited", "On")
                            //End If
                            //If rblQ6.SelectedValue = 2 Then
                            //    pdfFormFields.SetField("Q6Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);

                            //    ' Question 7
                            //If rblQ7.SelectedValue = 0 Then
                            //    pdfFormFields.SetField("Q7None", "On")
                            //End If
                            //If rblQ7.SelectedValue = 1 Then
                            //    pdfFormFields.SetField("Q7Limited", "On")
                            //End If
                            //If rblQ7.SelectedValue = 2 Then
                            //    pdfFormFields.SetField("Q7Considerable", "On")
                            //End If

                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            //' Question 8                           
                            pdfFormFields.SetField("Q8Description", model.Q8);
                            pdfFormFields.SetField("Q8Contact", model.NameQ8);
                            pdfFormFields.SetField("Q8Email", model.EmailQ8);
                            pdfFormFields.SetField("Q8Phone", model.PhoneNumQ8);

                            //    ' Signature
                            //If boxAgree.Checked Then
                            //    pdfFormFields.SetField("SigChkBox", "On")
                            //End If
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
