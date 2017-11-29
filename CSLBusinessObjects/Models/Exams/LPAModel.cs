using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class LPAModel
    {

        #region BasicInfo
        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "E-mail: ")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "E-mail Required in basic info")]
        public string Email { get; set; }

        [Display(Name = "Please affirm that you meet the following educational requirement: equivalent to graduation from a college or university and completion of a graduate degree from an accredited library school, or a library media credential issued by a teacher-credentialing commission authorizing service in California; or a graduate degree in a relevant or appropriate field.")]
        public bool HasEducation { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool LPAOneYearExp { get; set; }

        public bool LPATwoYearExp { get; set; }

        public bool LPAFiveYearExp { get; set; }
        #endregion

        #region Questions
        [Display(Name = "1. Please rate your experience in establishing and maintaining cooperative relationships with library patrons, coworkers, and the public.")]
        public bool Q1None { get; set; }

        public bool Q1Limited { get; set; }

        public bool Q1Considerable { get; set; }

        [Display(Name = "Please describe the techniques and strategies that you have used to establish and maintain cooperative relationships with library patrons, coworkers, and the public that support your rating. (900 characters max)")]
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


        [Display(Name = "2. Please rate your experience in developing and maintaining a discrimination and harassment free work environment.")]
        public bool Q2None { get; set; }

        public bool Q2Limited { get; set; }

        public bool Q2Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Discuss the number and composition of the workforce in which you worked and what you specific ally did to create a discrimination and harassment free workplace. (900 characters max)")]
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


        [Display(Name = "3. Please rate your experience in forming and/or working with teams or fostering teamwork among coworkers or work units.")]
        public bool Q3None { get; set; }

        public bool Q3Limited { get; set; }

        public bool Q3Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the nature of the team, its purpose or goals, and your role in the process. (900 characters max)")]
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


        [Display(Name = "4. Please rate your experience in the development, implementation, and or evaluation of library program criteria.")]
        public bool Q4None { get; set; }

        public bool Q4Limited { get; set; }

        public bool Q4Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the program, the criteria and/or metrics you developed and implemented and your assessment of their effectiveness as evaluative tools. (900 characters max)")]
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


        [Display(Name = "5. Please rate your experience in developing and using conflict resolution strategies.")]
        public bool Q5None { get; set; }

        public bool Q5Limited { get; set; }

        public bool Q5Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the situation in which you developed and/or used conflict resolution strategies and your role in the process. (900 characters max)")]
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
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 5")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 5")]
        public string PhoneNumQ5 { get; set; }


        [Display(Name = "6. Please rate your experience in supervising other employees.")]
        public bool Q6None { get; set; }

        public bool Q6Limited { get; set; }

        public bool Q6Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the number and types of employees supervised, directly or indirectly, and the breadth and scope of functions they performed. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 6")]
        public string Q6 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 6")]
        public string NameQ6 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 6")]
        public string EmailQ6 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 6")]
        public string PhoneNumQ6 { get; set; }


        [Display(Name = "7. Please rate your experience in managing a library budget or in evaluating the fiscal status of projects or the fiscal viability of proposals to fund activities.")]
        public bool Q7None { get; set; }

        public bool Q7Limited { get; set; }

        public bool Q7Considerable { get; set; }

        [Display(Name = "Please describe your fiscal management experience. Be specific about the size and complexity of the program, project or proposal that you managed or oversaw. (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 7")]
        public string Q7 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 8")]
        public string NameQ7 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 7")]
        public string EmailQ7 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 7")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 7")]
        public string PhoneNumQ7 { get; set; }


        [Display(Name = "8. Please describe the methods you use to stay abreast of best practices and the latest trends in library services and technology, for example, any association affiliations, conferences, seminars attended, training attended or given, or any other resources utilized. Discuss your role in any associations (e.g. member, officer) and the extent of your participation in conferences, seminars, or training programs (e.g. organizer, participant, speaker, etc.)")]
        [Required(ErrorMessage = "Please describe your experience for Question 8")]
        public string Q8 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        [Required(ErrorMessage = "Contact Required for Question 8")]
        public string NameQ8 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 8")]
        public string EmailQ8 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 8")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 8")]
        public string PhoneNumQ8 { get; set; }
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
