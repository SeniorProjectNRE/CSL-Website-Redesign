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
        public bool FillLibrarianExam(LibrarianModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillSeniorLibrarianExam(LibrarianModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.HasExperience == true)
                            {
                                pdfFormFields.SetField("SenLibTwoYearExp", "On");
                            }
                            if (model.HasExperience == false)
                            {
                                pdfFormFields.SetField("SenLibThreeYearExp", "On");
                            }

                            //Collection Experience
                            pdfFormFields.SetField("CollectionExp", model.CollectionDevelopment);
                            pdfFormFields.SetField("CollectionContact", model.NameCollectionDevelopment);
                            pdfFormFields.SetField("CollectionEmail", model.EmailCollectionDevelopment);
                            pdfFormFields.SetField("CollectionPhone", model.PhoneNumCollectionDevelopment);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.CatalogAndClass);
                            pdfFormFields.SetField("CatalogingContact", model.NameCatalogAndClass);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCatalogAndClass);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCatalogAndClass);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Specialized Experience
                            pdfFormFields.SetField("SpecializedExp", model.Specialized);
                            pdfFormFields.SetField("SpecializedContact", model.NameSpecialized);
                            pdfFormFields.SetField("SpecializedEmail", model.EmailSpecialized);
                            pdfFormFields.SetField("SpecializedPhone", model.PhoneNumSpecialized);
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

                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            pdfFormFields.SetField("Q8Description", model.Q8);
                            pdfFormFields.SetField("Q8Contact", model.NameQ8);
                            pdfFormFields.SetField("Q8Email", model.EmailQ8);
                            pdfFormFields.SetField("Q8Phone", model.PhoneNumQ8);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillSupervisingLibrarianIExam(SupervisingLibrarianModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.HasExperienceSLI == true)
                            {
                                pdfFormFields.SetField("SL1TwoYearExp", "On");
                            }
                            if (model.HasExperienceSLI == false)
                            {
                                pdfFormFields.SetField("SL1ThreeYearExp", "On");
                            }

                            //Collection Experience
                            pdfFormFields.SetField("CollectionExp", model.CollectionDevelopment);
                            pdfFormFields.SetField("CollectionContact", model.NameCollectionDevelopment);
                            pdfFormFields.SetField("CollectionEmail", model.EmailCollectionDevelopment);
                            pdfFormFields.SetField("CollectionPhone", model.PhoneNumCollectionDevelopment);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.CatalogAndClass);
                            pdfFormFields.SetField("CatalogingContact", model.NameCatalogAndClass);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCatalogAndClass);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCatalogAndClass);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Specialized Experience
                            pdfFormFields.SetField("SpecializedExp", model.Specialized);
                            pdfFormFields.SetField("SpecializedContact", model.NameSpecialized);
                            pdfFormFields.SetField("SpecializedEmail", model.EmailSpecialized);
                            pdfFormFields.SetField("SpecializedPhone", model.PhoneNumSpecialized);
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            if (model.Q6None == true)
                            {
                                pdfFormFields.SetField("Q6None", "On");
                            }
                            if (model.Q6Limited == true)
                            {
                                pdfFormFields.SetField("Q6Limited", "On");
                            }
                            if (model.Q6Considerable == true)
                            {
                                pdfFormFields.SetField("Q6Considerable", "On");
                            }
                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);

                            if (model.Q7None == true)
                            {
                                pdfFormFields.SetField("Q7None", "On");
                            }
                            if (model.Q7Limited == true)
                            {
                                pdfFormFields.SetField("Q7Limited", "On");
                            }
                            if (model.Q7Considerable == true)
                            {
                                pdfFormFields.SetField("Q7Considerable", "On");
                            }
                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            pdfFormFields.SetField("Q8Description", model.Q8);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillSupervisingLibrarianIIExam(SupervisingLibrarianModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.SL2OneYearExp == true)
                            {
                                pdfFormFields.SetField("SL2OneYearExp", "On");
                            }
                            if (model.SL2ThreeYearExp == true)
                            {
                                pdfFormFields.SetField("SL2ThreeYearExp", "On");
                            }
                            if (model.SL2FourYearExp == true)
                            {
                                pdfFormFields.SetField("SL2FourYearExp", "On");
                            }

                            //Collection Experience
                            pdfFormFields.SetField("CollectionExp", model.CollectionDevelopment);
                            pdfFormFields.SetField("CollectionContact", model.NameCollectionDevelopment);
                            pdfFormFields.SetField("CollectionEmail", model.EmailCollectionDevelopment);
                            pdfFormFields.SetField("CollectionPhone", model.PhoneNumCollectionDevelopment);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.CatalogAndClass);
                            pdfFormFields.SetField("CatalogingContact", model.NameCatalogAndClass);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCatalogAndClass);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCatalogAndClass);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Specialized Experience
                            pdfFormFields.SetField("SpecializedExp", model.Specialized);
                            pdfFormFields.SetField("SpecializedContact", model.NameSpecialized);
                            pdfFormFields.SetField("SpecializedEmail", model.EmailSpecialized);
                            pdfFormFields.SetField("SpecializedPhone", model.PhoneNumSpecialized);
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            if (model.Q6None == true)
                            {
                                pdfFormFields.SetField("Q6None", "On");
                            }
                            if (model.Q6Limited == true)
                            {
                                pdfFormFields.SetField("Q6Limited", "On");
                            }
                            if (model.Q6Considerable == true)
                            {
                                pdfFormFields.SetField("Q6Considerable", "On");
                            }
                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);

                            if (model.Q7None == true)
                            {
                                pdfFormFields.SetField("Q7None", "On");
                            }
                            if (model.Q7Limited == true)
                            {
                                pdfFormFields.SetField("Q7Limited", "On");
                            }
                            if (model.Q7Considerable == true)
                            {
                                pdfFormFields.SetField("Q7Considerable", "On");
                            }
                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            pdfFormFields.SetField("Q8Description", model.Q8);

                            if (model.Q9None == true)
                            {
                                pdfFormFields.SetField("Q9None", "On");
                            }
                            if (model.Q9Limited == true)
                            {
                                pdfFormFields.SetField("Q9Limited", "On");
                            }
                            if (model.Q9Considerable == true)
                            {
                                pdfFormFields.SetField("Q9Considerable", "On");
                            }
                            pdfFormFields.SetField("Q9Description", model.Q9);
                            pdfFormFields.SetField("Q9Contact", model.NameQ9);
                            pdfFormFields.SetField("Q9Email", model.EmailQ9);
                            pdfFormFields.SetField("Q9Phone", model.PhoneNumQ9);

                            if (model.Q10None == true)
                            {
                                pdfFormFields.SetField("Q10None", "On");
                            }
                            if (model.Q10Limited == true)
                            {
                                pdfFormFields.SetField("Q10Limited", "On");
                            }
                            if (model.Q10Considerable == true)
                            {
                                pdfFormFields.SetField("Q10Considerable", "On");
                            }
                            pdfFormFields.SetField("Q10Description", model.Q10);
                            pdfFormFields.SetField("Q10Contact", model.NameQ10);
                            pdfFormFields.SetField("Q10Email", model.EmailQ10);
                            pdfFormFields.SetField("Q10Phone", model.PhoneNumQ10);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillPrincipalLibrarianExam(SupervisingLibrarianModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.PLOneYearExp == true)
                            {
                                pdfFormFields.SetField("PLOneYearExp", "On");
                            }
                            if (model.PLTwoYearExp == true)
                            {
                                pdfFormFields.SetField("PLTwoYearExp", "On");
                            }
                            if (model.PLFiveYearExp == true)
                            {
                                pdfFormFields.SetField("PLFiveYearExp", "On");
                            }

                            //Collection Experience
                            pdfFormFields.SetField("CollectionExp", model.CollectionDevelopment);
                            pdfFormFields.SetField("CollectionContact", model.NameCollectionDevelopment);
                            pdfFormFields.SetField("CollectionEmail", model.EmailCollectionDevelopment);
                            pdfFormFields.SetField("CollectionPhone", model.PhoneNumCollectionDevelopment);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.CatalogAndClass);
                            pdfFormFields.SetField("CatalogingContact", model.NameCatalogAndClass);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCatalogAndClass);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCatalogAndClass);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Specialized Experience
                            pdfFormFields.SetField("SpecializedExp", model.Specialized);
                            pdfFormFields.SetField("SpecializedContact", model.NameSpecialized);
                            pdfFormFields.SetField("SpecializedEmail", model.EmailSpecialized);
                            pdfFormFields.SetField("SpecializedPhone", model.PhoneNumSpecialized);
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            if (model.Q6None == true)
                            {
                                pdfFormFields.SetField("Q6None", "On");
                            }
                            if (model.Q6Limited == true)
                            {
                                pdfFormFields.SetField("Q6Limited", "On");
                            }
                            if (model.Q6Considerable == true)
                            {
                                pdfFormFields.SetField("Q6Considerable", "On");
                            }
                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);

                            if (model.Q7None == true)
                            {
                                pdfFormFields.SetField("Q7None", "On");
                            }
                            if (model.Q7Limited == true)
                            {
                                pdfFormFields.SetField("Q7Limited", "On");
                            }
                            if (model.Q7Considerable == true)
                            {
                                pdfFormFields.SetField("Q7Considerable", "On");
                            }
                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            pdfFormFields.SetField("Q8Description", model.Q8);

                            if (model.Q9None == true)
                            {
                                pdfFormFields.SetField("Q9None", "On");
                            }
                            if (model.Q9Limited == true)
                            {
                                pdfFormFields.SetField("Q9Limited", "On");
                            }
                            if (model.Q9Considerable == true)
                            {
                                pdfFormFields.SetField("Q9Considerable", "On");
                            }
                            pdfFormFields.SetField("Q9Description", model.Q9);
                            pdfFormFields.SetField("Q9Contact", model.NameQ9);
                            pdfFormFields.SetField("Q9Email", model.EmailQ9);
                            pdfFormFields.SetField("Q9Phone", model.PhoneNumQ9);

                            if (model.Q10None == true)
                            {
                                pdfFormFields.SetField("Q10None", "On");
                            }
                            if (model.Q10Limited == true)
                            {
                                pdfFormFields.SetField("Q10Limited", "On");
                            }
                            if (model.Q10Considerable == true)
                            {
                                pdfFormFields.SetField("Q10Considerable", "On");
                            }
                            pdfFormFields.SetField("Q10Description", model.Q10);
                            pdfFormFields.SetField("Q10Contact", model.NameQ10);
                            pdfFormFields.SetField("Q10Email", model.EmailQ10);
                            pdfFormFields.SetField("Q10Phone", model.PhoneNumQ10);

                            if (model.Q11None == true)
                            {
                                pdfFormFields.SetField("Q11None", "On");
                            }
                            if (model.Q11Limited == true)
                            {
                                pdfFormFields.SetField("Q11Limited", "On");
                            }
                            if (model.Q11Considerable == true)
                            {
                                pdfFormFields.SetField("Q11Considerable", "On");
                            }
                            pdfFormFields.SetField("Q11Description", model.Q11);
                            pdfFormFields.SetField("Q11Contact", model.NameQ11);
                            pdfFormFields.SetField("Q11Email", model.EmailQ11);
                            pdfFormFields.SetField("Q11Phone", model.PhoneNumQ11);

                            if (model.Q12None == true)
                            {
                                pdfFormFields.SetField("Q12None", "On");
                            }
                            if (model.Q12Limited == true)
                            {
                                pdfFormFields.SetField("Q12Limited", "On");
                            }
                            if (model.Q12Considerable == true)
                            {
                                pdfFormFields.SetField("Q12Considerable", "On");
                            }
                            pdfFormFields.SetField("Q12Description", model.Q12);
                            pdfFormFields.SetField("Q12Contact", model.NameQ12);
                            pdfFormFields.SetField("Q12Email", model.EmailQ12);
                            pdfFormFields.SetField("Q12Phone", model.PhoneNumQ12);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillLPAExam(LPAModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.LPAOneYearExp == true)
                            {
                                pdfFormFields.SetField("LPAOneYearExp", "On");
                            }
                            if (model.LPATwoYearExp == true)
                            {
                                pdfFormFields.SetField("LPATwoYearExp", "On");
                            }
                            if (model.LPAFiveYearExp == true)
                            {
                                pdfFormFields.SetField("LPAFiveYearExp", "On");
                            }
                            #endregion

                            #region Questions
                            if(model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            if (model.Q6None == true)
                            {
                                pdfFormFields.SetField("Q6None", "On");
                            }
                            if (model.Q6Limited == true)
                            {
                                pdfFormFields.SetField("Q6Limited", "On");
                            }
                            if (model.Q6Considerable == true)
                            {
                                pdfFormFields.SetField("Q6Considerable", "On");
                            }
                            pdfFormFields.SetField("Q6Description", model.Q6);
                            pdfFormFields.SetField("Q6Contact", model.NameQ6);
                            pdfFormFields.SetField("Q6Email", model.EmailQ6);
                            pdfFormFields.SetField("Q6Phone", model.PhoneNumQ6);

                            if (model.Q7None == true)
                            {
                                pdfFormFields.SetField("Q7None", "On");
                            }
                            if (model.Q7Limited == true)
                            {
                                pdfFormFields.SetField("Q7Limited", "On");
                            }
                            if (model.Q7Considerable == true)
                            {
                                pdfFormFields.SetField("Q7Considerable", "On");
                            }
                            pdfFormFields.SetField("Q7Description", model.Q7);
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);

                            pdfFormFields.SetField("Q8Description", model.Q8);
                            pdfFormFields.SetField("Q8Contact", model.NameQ8);
                            pdfFormFields.SetField("Q8Email", model.EmailQ8);
                            pdfFormFields.SetField("Q8Phone", model.PhoneNumQ8);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillLPCExam(LPCModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasEducation == true)
                            {
                                pdfFormFields.SetField("EduYes", "On");
                            }
                            if (model.HasEducation == false)
                            {
                                pdfFormFields.SetField("EduNo", "On");
                            }

                            if (model.OneYearExp == true)
                            {
                                pdfFormFields.SetField("OneYearExp", "On");
                            }
                            if (model.TwoYearExp == true)
                            {
                                pdfFormFields.SetField("TwoYearExp", "On");
                            }
                            if (model.FourYearExp == true)
                            {
                                pdfFormFields.SetField("FourYearExp", "On");
                            }
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);

                            pdfFormFields.SetField("Q6Description", model.Q6);

                            if (model.Q7Average == true)
                            {
                                pdfFormFields.SetField("Q7None", "On");
                            }
                            if (model.Q7AboveAverage == true)
                            {
                                pdfFormFields.SetField("Q7Limited", "On");
                            }
                            if (model.Q7Outstanding == true)
                            {
                                pdfFormFields.SetField("Q7Considerable", "On");
                            }
                            pdfFormFields.SetField("Q7Contact", model.NameQ7);
                            pdfFormFields.SetField("Q7Email", model.EmailQ7);
                            pdfFormFields.SetField("Q7Phone", model.PhoneNumQ7);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillLTAIExam(LTAModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasExperienceLTAII == true)
                            {
                                pdfFormFields.SetField("LTA1Degree", "On");
                            }
                            if (model.HasExperienceLTAI == false)
                            {
                                pdfFormFields.SetField("LTA1TwoYearExp", "On");
                            }

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.Cataloging);
                            pdfFormFields.SetField("CatalogingContact", model.NameCataloging);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCataloging);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCataloging);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Reserves Experience
                            pdfFormFields.SetField("ReservesExp", model.Reserves);
                            pdfFormFields.SetField("ReservesContact", model.NameReserves);
                            pdfFormFields.SetField("ReservesEmail", model.EmailReserves);
                            pdfFormFields.SetField("ReservesPhone", model.PhoneNumReserves);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Reader Advisory Service Experience
                            pdfFormFields.SetField("ReaderAdvisoryExp", model.ReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryContact", model.NameReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryEmail", model.EmailReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryPhone", model.PhoneNumReaderAdvisoryService);

                            //Interlibrary Loans Experience
                            pdfFormFields.SetField("InterlibraryLoansExp", model.InterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansContact", model.NameInterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansEmail", model.EmailInterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansPhone", model.PhoneNumInterlibraryLoans);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillLTAIIExam(LTAModel model, string pdfTemplate, string newFile)
        {
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

                            if (model.HasExperienceLTAII == true)
                            {
                                pdfFormFields.SetField("LTA1Degree", "On");
                            }
                            if (model.HasExperienceLTAI == false)
                            {
                                pdfFormFields.SetField("LTA1TwoYearExp", "On");
                            }

                            //Cataloging Experience
                            pdfFormFields.SetField("CatalogingExp", model.Cataloging);
                            pdfFormFields.SetField("CatalogingContact", model.NameCataloging);
                            pdfFormFields.SetField("CatalogingEmail", model.EmailCataloging);
                            pdfFormFields.SetField("CatalogingPhone", model.PhoneNumCataloging);

                            //Acquisition Experience
                            pdfFormFields.SetField("AcquisitionExp", model.Acquisitions);
                            pdfFormFields.SetField("AcquisitionContact", model.NameAcquisitions);
                            pdfFormFields.SetField("AcquisitionEmail", model.EmailAcquisitions);
                            pdfFormFields.SetField("AcquisitionPhone", model.PhoneNumAcquisitions);

                            //Reserves Experience
                            pdfFormFields.SetField("ReservesExp", model.Reserves);
                            pdfFormFields.SetField("ReservesContact", model.NameReserves);
                            pdfFormFields.SetField("ReservesEmail", model.EmailReserves);
                            pdfFormFields.SetField("ReservesPhone", model.PhoneNumReserves);

                            //Reference Experience
                            pdfFormFields.SetField("ReferenceExp", model.Reference);
                            pdfFormFields.SetField("ReferenceContact", model.NameReference);
                            pdfFormFields.SetField("ReferenceEmail", model.EmailReference);
                            pdfFormFields.SetField("ReferencePhone", model.PhoneNumReference);

                            //Preservation Experience
                            pdfFormFields.SetField("PreservationExp", model.Preservation);
                            pdfFormFields.SetField("PreservationContact", model.NamePreservation);
                            pdfFormFields.SetField("PreservationEmail", model.EmailPreservation);
                            pdfFormFields.SetField("PreservationPhone", model.PhoneNumPreservation);

                            //Reader Advisory Service Experience
                            pdfFormFields.SetField("ReaderAdvisoryExp", model.ReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryContact", model.NameReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryEmail", model.EmailReaderAdvisoryService);
                            pdfFormFields.SetField("ReaderAdvisoryPhone", model.PhoneNumReaderAdvisoryService);

                            //Interlibrary Loans Experience
                            pdfFormFields.SetField("InterlibraryLoansExp", model.InterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansContact", model.NameInterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansEmail", model.EmailInterlibraryLoans);
                            pdfFormFields.SetField("InterlibraryLoansPhone", model.PhoneNumInterlibraryLoans);

                            //Circulation Experience
                            pdfFormFields.SetField("CirculationExp", model.Circulation);
                            pdfFormFields.SetField("CirculationContact", model.NameCirculation);
                            pdfFormFields.SetField("CirculationEmail", model.EmailCirculation);
                            pdfFormFields.SetField("CirculationPhone", model.PhoneNumCirculation);
                            #endregion

                            #region Questions
                            if (model.Q1None == true)
                            {
                                pdfFormFields.SetField("Q1None", "On");
                            }
                            if (model.Q1Limited == true)
                            {
                                pdfFormFields.SetField("Q1Limited", "On");
                            }
                            if (model.Q1Considerable == true)
                            {
                                pdfFormFields.SetField("Q1Considerable", "On");
                            }
                            pdfFormFields.SetField("Q1Description", model.Q1);
                            pdfFormFields.SetField("Q1Contact", model.NameQ1);
                            pdfFormFields.SetField("Q1Email", model.EmailQ1);
                            pdfFormFields.SetField("Q1Phone", model.PhoneNumQ1);

                            if (model.Q2None == true)
                            {
                                pdfFormFields.SetField("Q2None", "On");
                            }
                            if (model.Q2Limited == true)
                            {
                                pdfFormFields.SetField("Q2Limited", "On");
                            }
                            if (model.Q2Considerable == true)
                            {
                                pdfFormFields.SetField("Q2Considerable", "On");
                            }
                            pdfFormFields.SetField("Q2Description", model.Q2);
                            pdfFormFields.SetField("Q2Contact", model.NameQ2);
                            pdfFormFields.SetField("Q2Email", model.EmailQ2);
                            pdfFormFields.SetField("Q2Phone", model.PhoneNumQ2);

                            if (model.Q3None == true)
                            {
                                pdfFormFields.SetField("Q3None", "On");
                            }
                            if (model.Q3Limited == true)
                            {
                                pdfFormFields.SetField("Q3Limited", "On");
                            }
                            if (model.Q3Considerable == true)
                            {
                                pdfFormFields.SetField("Q3Considerable", "On");
                            }
                            pdfFormFields.SetField("Q3Description", model.Q3);
                            pdfFormFields.SetField("Q3Contact", model.NameQ3);
                            pdfFormFields.SetField("Q3Email", model.EmailQ3);
                            pdfFormFields.SetField("Q3Phone", model.PhoneNumQ3);

                            if (model.Q4None == true)
                            {
                                pdfFormFields.SetField("Q4None", "On");
                            }
                            if (model.Q4Limited == true)
                            {
                                pdfFormFields.SetField("Q4Limited", "On");
                            }
                            if (model.Q4Considerable == true)
                            {
                                pdfFormFields.SetField("Q4Considerable", "On");
                            }
                            pdfFormFields.SetField("Q4Description", model.Q4);
                            pdfFormFields.SetField("Q4Contact", model.NameQ4);
                            pdfFormFields.SetField("Q4Email", model.EmailQ4);
                            pdfFormFields.SetField("Q4Phone", model.PhoneNumQ4);

                            if (model.Q5None == true)
                            {
                                pdfFormFields.SetField("Q5None", "On");
                            }
                            if (model.Q5Limited == true)
                            {
                                pdfFormFields.SetField("Q5Limited", "On");
                            }
                            if (model.Q5Considerable == true)
                            {
                                pdfFormFields.SetField("Q5Considerable", "On");
                            }
                            pdfFormFields.SetField("Q5Description", model.Q5);
                            pdfFormFields.SetField("Q5Contact", model.NameQ5);
                            pdfFormFields.SetField("Q5Email", model.EmailQ5);
                            pdfFormFields.SetField("Q5Phone", model.PhoneNumQ5);
                            #endregion

                            if (model.isCertified == true)
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool FillForm(LibrarianModel model, string pdfTemplate, string newFile)
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
            return true;
        }

    }
}
