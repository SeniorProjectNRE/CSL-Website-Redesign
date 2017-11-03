using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class LibrarianModel
    {

        #region Examinations
        [Display(Name = "Librarian")]
        public bool IsLibrarian { get; set; }

        [Display(Name = "Senior Librarian")]
        public bool IsSeniorLibrarian { get; set; }
        #endregion

        #region BasicInfo
        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "E-mail: ")]
        [RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid e-mail address")]
        [Required(ErrorMessage = "E-mail Required in basic info")]
        public string Email { get; set; }

        [Display(Name = "Please affirm that you meet the following educational requirement: equivalent to graduation from a college or university and completion of a graduate degree from an accredited library school. (Registration as a graduate student in a library school will admit applicants to the examination, but evidence of completion of the required graduate degree must be submitted before an applicant can be considered eligible for appointment)")]
        public bool HasEducation { get; set; }

        [Display(Name = "If not, check here if you are a registered graduate student in a library school.")]
        public bool IfNot { get; set; }

        [Display(Name = "Please describe the way in which your experience meets the minimum requirements for participation in this examination.")]
        public bool HasExperience { get; set; }

        [Display(Name = "Standard Search Strategies")]
        public string SearchStrategies { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameSearchStrategies { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailSearchStrategies { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumSearchStrategies { get; set; }

        [Display(Name = "Collection Development")]
        public string CollectionDeveopment { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCollectionDeveopment { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCollectionDeveopment { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCollectionDeveopment { get; set; }

        [Display(Name = "Bibliographic Information Sources")]
        public string BibliographicInfo{ get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameBibliographicInfo { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailBibliographicInfo { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumBibliographicInfo { get; set; }

        [Display(Name = "Computerized Databases")]
        public string ComputerizedData { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameComputerizedData { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailComputerizedData { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumComputerizedData { get; set; }

        [Display(Name = "Acquisitions")]
        public string Acquisitions { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameAcquisitions { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailAcquisitions { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumAcquisitions { get; set; }

        [Display(Name = "Cataloging and Classification")]
        public string CatalogAndClass{ get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCatalogAndClass { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCatalogAndClass { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCatalogAndClass { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameReference { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailReference { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumReference { get; set; }

        [Display(Name = "Circulation")]
        public string Circulation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameCirculation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailCirculation { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumCirculation { get; set; }

        [Display(Name = "Preservation of Library Material")]
        public string Preservation { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NamePreservation { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailPreservation { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumPreservation { get; set; }

        [Display(Name = "Specialized Function or Collection (eg. law, medical, Braille and talking book library, etc.)")]
        public string Specialized { get; set; }

        [Display(Name = "Name of person who can verify this experience:")]
        public string NameSpecialized { get; set; }

        [Display(Name = "E-mail of person listed above who can verify this experience:")]
        public string EmailSpecialized { get; set; }

        [Display(Name = "Phone Number of person listed above who can verify this experience:")]
        public string PhoneNumSpecialized { get; set; }
        #endregion


        #region Questions
        [Display(Name = "1. Please describe the strategies and techniques you would use to create and foster a customer service focus in a library setting.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 1")]
        public string PhoneNumQ1 { get; set; }

        [Display(Name = "2. Please describe the methods you use to stay abreast of best practices and the latest trends in library services and technology, for example, any association affiliations, conferences, seminars attended, training attended or given, or any other resources utilized.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 2")]
        public string PhoneNumQ2 { get; set; }

        [Display(Name = "3. Please describe the techniques and strategies that you would use to establish and maintain cooperative relationships with library patrons, coworkers, and the public.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 3")]
        public string PhoneNumQ3 { get; set; }

        [Display(Name = "4. Please describe the social and library trends that have impacted the way people communicate and seek information.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 4")]
        public string PhoneNumQ4 { get; set; }

        [Display(Name = "5. Please describe your experience in forming and/or working with teams or fostering teamwork among co-workers. Be specific about the nature of the team, its purpose or goals, and your role in the process.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 5")]
        public string PhoneNumQ5 { get; set; }

        [Display(Name = "6. Please describe your public speaking experience before large or small groups. This does not have to be in a library setting.")]
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

        [Display(Name = "7. Please describe your experience as a “lead” over other employees. Discuss how “lead” responsibilities are different from “supervision” and what techniques you used to guide and train employees assigned to you.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 7")]
        public string PhoneNumQ7 { get; set; }

        [Display(Name = "8. Please describe any expertise or experience that you have working with specialized collections. Be specific about the nature and size of the collection.")]
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
        [Required(ErrorMessage = "Contact's Phone Number Required for Question 8")]
        public string PhoneNumQ8 { get; set; }
        #endregion

        #region Upload
        [Display(Name = "Resume")]
        //[Required(ErrorMessage = "Please upload your resume")]
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
        [Required(ErrorMessage = "Please type today's date")]
        public string Date { get; set; }
        #endregion
    }
}
