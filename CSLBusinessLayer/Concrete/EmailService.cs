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

namespace CSLBusinessLayer.Concrete
{
    public class EmailService : IEmailService
    {
        public SuccessModel SendLibrarianExamEmail(string file, LibrarianModel model)
        {
            SuccessModel res;

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("seniorprojectteamnre@gmail.com", "Testing!23");

            Attachment pdf = new Attachment(file);

            MailMessage mm = new MailMessage("seniorprojectteamnre@gmail.com", "matthewloller@gmail.com", "Exam Submission", file);
            mm.IsBodyHtml = true;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            mm.Attachments.Add(pdf);
            foreach (var item in model.ResumeUpload)
            {
                if (item != null && item.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(item.FileName);
                        var attachment = new Attachment(item.InputStream, fileName);
                        mm.Attachments.Add(attachment);
                    }
                    catch (Exception) { }
                }
            }

            client.Send(mm);

            File.Delete(file);
            
            res = new SuccessModel() { SuccessMessage = "Form has been successfully submitted" };
            return res;
        }

        public SuccessModel SendSutroClassEmail(SutroClassModel model)
        {
            SuccessModel res;

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

            res = new SuccessModel() { SuccessMessage = "Form has been successfully submitted"};
            return res;
        }

        private string SutroClassEmailBuilder(SutroClassModel model)
        {
            string res = "<b>Instruction requested by: </b>"+model.Instructor +
                         "<br /><b>Email: </b>" + model.InstructorEmail+
                         "<br /><b>Department: </b>" + model.InstructorDepartment+
                         "<br /><b>Course number and title: </b>" + model.CourseNumandTitle+
                         "<br /><b>The date, time, and frequency of your class visit (one time, multiple, or all quarter): </b>" + model.Frequency+
                         "<br /><b>The approximate number of students in each class: </b>" + model.StudentAmount+
                         "<br /><b>How long your class session at the Sutro will be (half hour, an hour, etc.): </b>" + model.ClassTimeLength+
                         "<br /><b>Is there an assignment, paper, or project the students will have to complete using Special Collections materials during the quarter? Is group study a requirement?: </b>" + model.DoesAssignmentExist+
                         "<br /><b>List of the materials to be used (please allow at least 3-4 days before the date of the scheduled class meeting): </b>" + model.Materials;
            return res;
        }
    }
}
