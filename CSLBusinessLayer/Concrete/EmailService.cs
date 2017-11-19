using CSLBusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSLBusinessObjects.Models;
using System.Net.Mail;
using System.Web;
using System.IO;
using CSLBusinessObjects.Models.Exams;
using System.Web.Hosting;

namespace CSLBusinessLayer.Concrete
{
    public class EmailService : IEmailService
    {
        public bool SendLibrarianExamEmail(string file, LibrarianModel model)
        {
            try
            {
                // Command line argument must the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("seniorprojectteamnre@gmail.com", "Testing!23");

                string subject;
                if (model.IsLibrarian = true && model.IsSeniorLibrarian == false)
                {
                    subject = "New Librarian Supplemental Application - " + model.Name;
                }
                else subject = "New Senior Librarian Supplemental Application - " + model.Name;

                MailMessage mm = new MailMessage("seniorprojectteamnre@gmail.com", "matthewloller@gmail.com", subject, LibrarianExamEmailBuilder(model));
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;



                mm.Attachments.Add(new Attachment(HostingEnvironment.MapPath(file)));
                if (model.ResumeUpload != null && model.ResumeUpload.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(model.ResumeUpload.FileName);
                        var attachment = new Attachment(model.ResumeUpload.InputStream, fileName);
                        mm.Attachments.Add(attachment);
                    }
                    catch (Exception) { }
                }

                client.Send(mm);

                mm.Attachments.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendSupervisingLibrarianExamEmail(string file, SupervisingLibrarianModel model)
        {
            try
            {
                // Command line argument must the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("seniorprojectteamnre@gmail.com", "Testing!23");

                string subject;
                if (model.IsSupervisingLibrarianI = true && model.IsSupervisingLibrarianII == false && model.IsPrincipalLibrarian == false)
                {
                    subject = "New Supervising Librarian I Supplemental Application - " + model.Name;
                }
                else if (model.IsSupervisingLibrarianI = false && model.IsSupervisingLibrarianII == true && model.IsPrincipalLibrarian == false)
                {
                    subject = "New Supervising Librarian II Supplemental Application - " + model.Name;
                }
                else subject = "New Principal Librarian Supplemental Application - " + model.Name;

                MailMessage mm = new MailMessage("seniorprojectteamnre@gmail.com", "matthewloller@gmail.com", subject, SupervisingLibrarianExamEmailBuilder(model));
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;



                mm.Attachments.Add(new Attachment(HostingEnvironment.MapPath(file)));
                if (model.ResumeUpload != null && model.ResumeUpload.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(model.ResumeUpload.FileName);
                        var attachment = new Attachment(model.ResumeUpload.InputStream, fileName);
                        mm.Attachments.Add(attachment);
                    }
                    catch (Exception) { }
                }

                client.Send(mm);

                mm.Attachments.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendLPAExamEmail(string file, LPAModel model)
        {
            try
            {
                // Command line argument must the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("seniorprojectteamnre@gmail.com", "Testing!23");

                string subject = "New Library Programs Administrator Supplemental Application - " + model.Name;

                MailMessage mm = new MailMessage("seniorprojectteamnre@gmail.com", "matthewloller@gmail.com", subject, LPAExamEmailBuilder(model));
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;



                mm.Attachments.Add(new Attachment(HostingEnvironment.MapPath(file)));
                if (model.ResumeUpload != null && model.ResumeUpload.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(model.ResumeUpload.FileName);
                        var attachment = new Attachment(model.ResumeUpload.InputStream, fileName);
                        mm.Attachments.Add(attachment);
                    }
                    catch (Exception) { }
                }

                client.Send(mm);

                mm.Attachments.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendSutroClassEmail(SutroClassModel model)
        {
            try
            {
                // Command line argument must the the SMTP host.
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("seniorprojectteamnre@gmail.com", "Testing!23");

                MailMessage mm = new MailMessage("seniorprojectteamnre@gmail.com", "matthewloller@gmail.com", "Sutro Reservation Request", SutroClassEmailBuilder(model));
                mm.IsBodyHtml = true;
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string SutroClassEmailBuilder(SutroClassModel model)
        {
            string res = "<b>Instruction requested by: </b>" + model.Instructor +
                         "<br /><b>Email: </b>" + model.InstructorEmail +
                         "<br /><b>Department: </b>" + model.InstructorDepartment +
                         "<br /><b>Course number and title: </b>" + model.CourseNumandTitle +
                         "<br /><b>The date, time, and frequency of your class visit (one time, multiple, or all quarter): </b>" + model.Frequency +
                         "<br /><b>The approximate number of students in each class: </b>" + model.StudentAmount +
                         "<br /><b>How long your class session at the Sutro will be (half hour, an hour, etc.): </b>" + model.ClassTimeLength +
                         "<br /><b>Is there an assignment, paper, or project the students will have to complete using Special Collections materials during the quarter? Is group study a requirement?: </b>" + model.DoesAssignmentExist +
                         "<br /><b>List of the materials to be used (please allow at least 3-4 days before the date of the scheduled class meeting): </b>" + model.Materials;
            return res;
        }

        private string LibrarianExamEmailBuilder(LibrarianModel model)
        {
            string res = "<b>Please send a confirmation e-mail back to " + model.Name + " at: " + model.Email + " </b>";
            return res;
        }

        private string SupervisingLibrarianExamEmailBuilder(SupervisingLibrarianModel model)
        {
            string res = "<b>Please send a confirmation e-mail back to " + model.Name + " at: " + model.Email + " </b>";
            return res;
        }

        private string LPAExamEmailBuilder(LPAModel model)
        {
            string res = "<b>Please send a confirmation e-mail back to " + model.Name + " at: " + model.Email + " </b>";
            return res;
        }

    }
}
