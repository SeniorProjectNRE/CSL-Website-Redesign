using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class SupervisingLibrarianModel
    {

        #region Examinations
        [Display(Name = "Supervising Librarian I")]
        public bool IsSupervisingLibrarianI { get; set; }

        [Display(Name = "Supervising Librarian II")]
        public bool IsSupervisingLibrarianII { get; set; }

        [Display(Name = "Principal Librarian")]
        public bool IsPrincipalLibrarian { get; set; }
        #endregion

        #region BasicInfo
        [Display(Name = "Name: ")]
        //[Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "E-mail: ")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "E-mail Required in basic info")]
        public string Email { get; set; }

        [Display(Name = "Please affirm that you meet the following educational requirement: equivalent to graduation from a college or university and completion of a graduate degree from an accredited library school, or a library media credential issued by a teacher-credentialing commission authorizing service in California; or a graduate degree in a relevant or appropriate field.")]
        public bool HasEducation { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool HasExperienceSLI { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool SL2OneYearExp { get; set; }

        public bool SL2ThreeYearExp { get; set; }

        public bool SL2FourYearExp { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool PLOneYearExp { get; set; }

        public bool PLTwoYearExp { get; set; }

        public bool PLFiveYearExp { get; set; }

        [Display(Name = "Collection Development")]
        public string CollectionDevelopment { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCollectionDevelopment { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCollectionDevelopment { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCollectionDevelopment { get; set; }

        [Display(Name = "Bibliographic Information Sources")]
        public string BibliographicInfo { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameBibliographicInfo { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailBibliographicInfo { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumBibliographicInfo { get; set; }

        [Display(Name = "Computerized Databases")]
        public string ComputerizedData { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameComputerizedData { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailComputerizedData { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumComputerizedData { get; set; }

        [Display(Name = "Acquisitions")]
        public string Acquisitions { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameAcquisitions { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailAcquisitions { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumAcquisitions { get; set; }

        [Display(Name = "Cataloging and Classification")]
        public string CatalogAndClass { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCatalogAndClass { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCatalogAndClass { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCatalogAndClass { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameReference { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailReference { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumReference { get; set; }

        [Display(Name = "Circulation")]
        public string Circulation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCirculation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCirculation { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCirculation { get; set; }

        [Display(Name = "Preservation of Library Material")]
        public string Preservation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NamePreservation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailPreservation { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumPreservation { get; set; }

        [Display(Name = "Specialized Function or Collection (eg. law, medical, Braille and talking book library, etc.)")]
        public string Specialized { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameSpecialized { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailSpecialized { get; set; }

        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number in Basic Info")]
        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumSpecialized { get; set; }
        #endregion

        #region Questions
        [Display(Name = "1. Please rate your experience in creating and fostering a customer service focus in a library setting.")]
        public bool RateQ1 { get; set; }

        [Display(Name = "Please describe your experience in creating and fostering a customer service focus in a library setting that supports your self-rating. Be specific about the strategies and techniques you used and which proved to be the most successful.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 1")]
        public string Q1 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 1")]
        public string NameQ1 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 1")]
        public string EmailQ1 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 1")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 1")]
        public string PhoneNumQ1 { get; set; }


        [Display(Name = "2. Please rate your knowledge and experience in establishing standard competencies among staff to ensure that staff members are evaluated equally and fairly.")]
        public bool RateQ2 { get; set; }

        [Display(Name = "Please describe your experience in establishing standard staff competencies that supports your self-rating. Be specific about the competencies, how they were developed, and how you implemented and monitored them.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 2")]
        public string Q2 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 2")]
        public string NameQ2 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 2")]
        public string EmailQ2 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 2")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 2")]
        public string PhoneNumQ2 { get; set; }


        [Display(Name = "3. Please rate your experience with the development and/or revision of library policies and procedures.")]
        public bool RateQ3 { get; set; }

        [Display(Name = "Please describe your professional library experience that supports your rating. Discuss the subject of the policy or procedure, the problem to be addressed and the way in which the policy addressed this problem. Please be specific regarding your role in the process.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 3")]
        public string Q3 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 3")]
        public string NameQ3 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 3")]
        public string EmailQ3 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 3")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 3")]
        public string PhoneNumQ3 { get; set; }


        [Display(Name = "4. Please rate your experience in developing and maintaining a discrimination and harassment free work environment. ")]
        public bool RateQ4 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Discuss the number and composition of the workforce in which you worked and what you specifically did to create a discrimination and harassment free workplace.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 4")]
        public string Q4 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 4")]
        public string NameQ4 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 4")]
        public string EmailQ4 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 4")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 4")]
        public string PhoneNumQ4 { get; set; }


        [Display(Name = "5. Please rate your experience in forming and/or working with teams or fostering teamwork among co-workers or work units.")]
        public bool RateQ5 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the nature of the team, its purpose or goals, and your role in the process.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 5")]
        public string Q5 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 5")]
        public string NameQ5 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 5")]
        public string EmailQ5 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 6")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 5")]
        public string PhoneNumQ5 { get; set; }


        [Display(Name = "6. Please rate your experience in developing and using conflict resolution strategies.")]
        public bool RateQ6 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the situation in which you developed and/or used conflict resolution strategies and your role in the process.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 6")]
        public string Q6 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 6")]
        public string NameQ6 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 6")]
        public string EmailQ6 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 6")]
        public string PhoneNumQ6 { get; set; }


        [Display(Name = "7. Please rate your experience in supervising other employees.")]
        public bool RateQ7 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the number and types of employees supervised, directly or indirectly, and the breadth and scope of functions they performed.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 7")]
        public string Q7 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 8")]
        public string NameQ7 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 7")]
        public string EmailQ7 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 7")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 7")]
        public string PhoneNumQ7 { get; set; }


        [Display(Name = "8. Please describe the methods you use to stay abreast of best practices and the latest trends in library services and technology, for example, any association affiliations, conferences, seminars attended, training attended or given, or any other resources utilized.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 8")]
        public string Q8 { get; set; }


        [Display(Name = "9. Please rate your experience managing a library budget.")]
        public bool RateQ9 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the size and complexity of the budget, whether it was for a unit/section/division/department/organization, and your role in the process.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 9")]
        public string Q9 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 9")]
        public string NameQ9 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 9")]
        public string EmailQ9 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 9")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 9")]
        public string PhoneNumQ9 { get; set; }


        [Display(Name = "10. Please rate your experience in developing and/or implementing strategic goals and objectives.")]
        public bool RateQ10 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the setting in which you engaged in strategic planning, the types of goals and objectives that were formulated and your role in the process.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 10")]
        public string Q10 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 10")]
        public string NameQ10 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 10")]
        public string EmailQ10 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 10")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 10")]
        public string PhoneNumQ10 { get; set; }


        [Display(Name = "11. Please rate your skill and experience as a leader (as opposed to a manager).")]
        public bool RateQ11 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about your leadership traits and how you demonstrate the elements of effective leadership.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 11")]
        public string Q11 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 11")]
        public string NameQ11 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 11")]
        public string EmailQ11 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 11")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 11")]
        public string PhoneNumQ11 { get; set; }


        [Display(Name = "12. Please rate your experience in the development, implementation, and or evaluation of library program criteria.")]
        public bool RateQ12 { get; set; }

        [Display(Name = "Please describe your experience that supports your rating. Be specific about the program, the criteria and/or metrics you developed and implemented and your assessment of their effectiveness as evaluative tools.")]
        //[Required(ErrorMessage = "Please describe your experience for Question 12")]
        public string Q12 { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        //[Required(ErrorMessage = "Contact Required for Question 12")]
        public string NameQ12 { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        //[RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        //[Required(ErrorMessage = "Contact's E-mail Required for Question 12")]
        public string EmailQ12 { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        //[RegularExpression("((\\(\\d{3}\\) ?)|(\\d{3}-))?\\d{3}-\\d{4}", ErrorMessage = "Please enter a valid phone number for Question 12")]
        //[Required(ErrorMessage = "Contact's Phone Number Required for Question 12")]
        public string PhoneNumQ12 { get; set; }
        #endregion

        #region Upload
        [Display(Name = "Resume")]
        ////[Required(ErrorMessage = "Please upload your resume in .pdf or .doc/docx format")]
        public HttpPostedFileBase ResumeUpload { get; set; }

        #endregion

        #region Sign
        [Display(Name = "By checking this box, I hereby certify under penalty of perjury that the information I have entered on this application is true and complete to the best of my knowledge. I further understand that all information is subject to verification and that any false, incomplete, or incorrect statements may result in my disqualification from the examination process or dismissal from employment with the State of California. I authorize the employers and educational institutions identified on this application to release any information they may have concerning my employment or education to the State of California.")]
        //[Required(ErrorMessage = "Please check the checkbox for agreement")]
        public bool isCertified { get; set; }

        [Display(Name = "Signature: ")]
        //[Required(ErrorMessage = "Please sign")]
        public string Signature { get; set; }

        [Display(Name = "Date: ")]
        //[RegularExpression(@"^\d{1,2}\/\d{1,2}\/\d{4}$", ErrorMessage = "Please enter a valid date.")]
        //[Required(ErrorMessage = "Please type today's date")]
        public string Date { get; set; }

        public bool IsCaptcha { get; set; }

        public bool Success { get; set; }
        #endregion


    }
}
