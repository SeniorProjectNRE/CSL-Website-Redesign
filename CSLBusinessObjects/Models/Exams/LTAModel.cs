using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class LTAModel
    {

        #region Examinations
        [Display(Name = "Library Technical Assistant I")]
        public bool IsLTAI { get; set; }

        [Display(Name = "Library Technical Assistant II")]
        public bool IsLTAII { get; set; }

        #endregion

        #region BasicInfo
        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "E-mail: ")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "E-mail Required in basic info")]
        public string Email { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool HasExperienceLTAI { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool HasExperienceLTAII { get; set; }

        [Display(Name = "Cataloging")]
        public string Cataloging { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCataloging { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCataloging { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCataloging { get; set; }

        [Display(Name = "Circulation")]
        public string Circulation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCirculation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCirculation { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCirculation { get; set; }

        [Display(Name = "Reserves")]
        public string Reserves { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameReserves { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailReserves { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumReserves { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameReference { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailReference { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumReference { get; set; }

        [Display(Name = "Preservation of Library Material")]
        public string Preservation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NamePreservation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailPreservation { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumPreservation { get; set; }

        [Display(Name = "Reader Advisory Service")]
        public string ReaderAdvisoryService { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameReaderAdvisoryService { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailReaderAdvisoryService { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumReaderAdvisoryService { get; set; }

        [Display(Name = "Interlibrary Loans")]
        public string InterlibraryLoans { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameInterlibraryLoans { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailInterlibraryLoans { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumInterlibraryLoans { get; set; }

        [Display(Name = "Acquisitions")]
        public string Acquisitions { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameAcquisitions { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailAcquisitions { get; set; }

        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumAcquisitions { get; set; }
        #endregion

        #region Questions
        [Display(Name = "1. Please rate your experience in creating and fostering good customer service in a library setting.")]
        public bool Q1None { get; set; }

        public bool Q1Limited { get; set; }

        public bool Q1Considerable { get; set; }

        [Display(Name = "Please describe your experience in creating and fostering a customer service focus in a library setting that supports your self-rating. Be specific about the strategies and techniques you used and which proved to be the most successful. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 1")]
        public string Q1 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 1")]
        public string NameQ1 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 1")]
        public string EmailQ1 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 1")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 1")]
        public string PhoneNumQ1 { get; set; }


        [Display(Name = "2. Please rate your experience in forming and/or working with teams or fostering teamwork among co-workers or work units.")]
        public bool Q2None { get; set; }

        public bool Q2Limited { get; set; }

        public bool Q2Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the nature of the team, its purpose or goals, and your role in the process. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 2")]
        public string Q2 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 2")]
        public string NameQ2 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 2")]
        public string EmailQ2 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 2")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 2")]
        public string PhoneNumQ2 { get; set; }


        [Display(Name = "3. Please rate your experience in establishing and maintaining effective working relationships with co-workers, supervisors, volunteers, and library patrons.")]
        public bool Q3None { get; set; }

        public bool Q3Limited { get; set; }

        public bool Q3Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the techniques and strategies you have used and whether they were successful or not. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 3")]
        public string Q3 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 3")]
        public string NameQ3 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 3")]
        public string EmailQ3 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 3")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 3")]
        public string PhoneNumQ3 { get; set; }


        [Display(Name = "4. Please rate your experience in supervising other employees.")]
        public bool Q4None { get; set; }

        public bool Q4Limited { get; set; }

        public bool Q4Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the number and types of employees supervised, directly or indirectly, and the breadth and scope of functions they performed. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 4")]
        public string Q4 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 4")]
        public string NameQ4 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 4")]
        public string EmailQ4 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 4")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 4")]
        public string PhoneNumQ4 { get; set; }


        [Display(Name = "5. Please rate your experience in training other employees.")]
        public bool Q5None { get; set; }

        public bool Q5Limited { get; set; }

        public bool Q5Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the number and types of employees trained, the training methods used, and the subject matter of the training. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 5")]
        public string Q5 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 5")]
        public string NameQ5 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 5")]
        public string EmailQ5 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 6")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 5")]
        public string PhoneNumQ5 { get; set; }
        #endregion

        #region Upload
        [Display(Name = "Resume")]
        //[Required(ErrorMessage = "Please upload your resume in .pdf or .doc/docx format")]
        public HttpPostedFileBase ResumeUpload { get; set; }

        #endregion

        #region Sign
        [Display(Name = "By checking this box, I hereby certify under penalty of perjury that the information I have entered on this application is true and complete to the best of my knowledge. I further understand that all information is subject to verification and that any false, incomplete, or incorrect statements may result in my disqualification from the examination process or dismissal from employment with the State of California. I authorize the employers and educational institutions identified on this application to release any information they may have concerning my employment or education to the State of California.")]
        [Required(ErrorMessage = "Please check the checkbox for agreement")]
        public bool isCertified { get; set; }

        [Display(Name = "Signature: ")]
        [Required(ErrorMessage = "Please sign")]
        public string Signature { get; set; }

        [Display(Name = "Date: ")]
        [RegularExpression(@"^\d{1,2}\/\d{1,2}\/\d{4}$", ErrorMessage = "Please enter a valid date.")]
        [Required(ErrorMessage = "Please type today's date")]
        public string Date { get; set; }

        public bool IsCaptcha { get; set; }

        public bool Success { get; set; }
        #endregion


    }
}
