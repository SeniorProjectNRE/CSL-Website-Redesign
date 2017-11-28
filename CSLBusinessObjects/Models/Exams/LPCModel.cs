using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class LPCModel
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
        public bool OneYearExp { get; set; }

        public bool TwoYearExp { get; set; }

        public bool FourYearExp { get; set; }
        #endregion

        #region Questions
        [Display(Name = "1. Please rate your experience in forming multi-agency library partnerships in order to achieve a common goal.")]
        public bool Q1None { get; set; }

        public bool Q1Limited { get; set; }

        public bool Q1Considerable { get; set; }

        [Display(Name = "Please describe your experience to support your rating. Discuss the nature of the partnership, what was the goal of the partnership, what was the outcome of the project, and specifically, what was your role. (900 characters max)")]
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


        [Display(Name = "2. Please rate your experience in developing, administering, or monitoring grant funding for projects or activities.")]
        public bool Q2None { get; set; }

        public bool Q2Limited { get; set; }

        public bool Q2Considerable { get; set; }

        [Display(Name = "Please describe your experience to support your rating. Discuss the nature of the grant funding, what was the goal of the project, what was the outcome of the grant, and specifically, what was your role. (900 characters max)")]
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


        [Display(Name = "3. Please rate your experience with the development and/or revision of library policies and procedures.")]
        public bool Q3None { get; set; }

        public bool Q3Limited { get; set; }

        public bool Q3Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Discuss the subject of the policy or procedure, the problem to be addressed and the way in which the policy addressed this problem. Please be specific regarding your role in the process. (900 characters max)")]
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


        [Display(Name = "4. Please rate your experience in conducting research and studies relating to the planning of grant programs. ")]
        public bool Q4None { get; set; }

        public bool Q4Limited { get; set; }

        public bool Q4Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Discuss the purpose of the research or study, the nature of the conclusions and recommendations, whether the study was presented in a written report and/or verbal presentation, and specifically, your role in the process. (900 characters max)")]
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


        [Display(Name = "5. Please rate your experience in evaluating library programs to determine their effectiveness and opportunities for improvement.")]
        public bool Q5None { get; set; }

        public bool Q5Limited { get; set; }

        public bool Q5Considerable { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Discuss a program that was evaluated, the extent and scope of the evaluation process, the evaluation instruments/techniques used and why they were selected, and specifically, your role in the process. (900 characters max)")]
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

         
        [Display(Name = "Discuss any association affiliations, conferences/seminars attended, training attended or given, or any other resources utilized. Discuss your roll in any associations (eg. member, officer) and the extent of your participation in conferences/seminars/training programs (organizer, participant, speaker, etc.) (900 characters max)")]
        [Required(ErrorMessage = "Please describe your experience for Question 6")]
        public string Q6 { get; set; }


        [Display(Name = "7. If one were to contact your current supervisor, how would he/she rate your overall work performance.")]
        public bool Q7Average { get; set; }

        public bool Q7AboveAverage { get; set; }

        public bool Q7Outstanding { get; set; }
        
        [Display(Name = "Name of current supervisor:")]
        [Required(ErrorMessage = "Contact Required for Question 7")]
        public string NameQ7 { get; set; }

        [Display(Name = "E-mail of current supervisor:")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "Contact's E-mail Required for Question 7")]
        public string EmailQ7 { get; set; }

        [Display(Name = "Phone Number of current supervisor:")]
        [RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 7")]
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 7")]
        public string PhoneNumQ7 { get; set; }
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
