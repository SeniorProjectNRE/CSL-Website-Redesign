using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSLBusinessObjects.Models.Exams
{
    public class LibrarianModel
    {
        #region Examinations
        public bool IsLibrarian { get; set; }

        public bool IsSeniorLibrarian { get; set; }
        #endregion

        #region BasicInfo
        public string Name { get; set; }

        public string Email { get; set; }

        public bool HasEducation { get; set; }

        public bool HasExperience { get; set; }

        public string SearchStrategies { get; set; }

        public string NameSearchStrategies { get; set; }

        public string EmailSearchStrategies { get; set; }

        public string PhoneNumSearchStrategies { get; set; }

        public string CollectionDeveopment { get; set; }

        public string NameCollectionDeveopment { get; set; }

        public string EmailCollectionDeveopment { get; set; }

        public string PhoneNumCollectionDeveopment { get; set; }

        public string BibliographicInfo{ get; set; }

        public string NameBibliographicInfo { get; set; }

        public string EmailBibliographicInfo { get; set; }

        public string PhoneNumBibliographicInfo { get; set; }

        public string ComputerizedData { get; set; }

        public string NameComputerizedData { get; set; }

        public string EmailComputerizedData { get; set; }

        public string PhoneNumComputerizedData { get; set; }

        public string Acquisitions { get; set; }

        public string NameAcquisitions { get; set; }

        public string EmailAcquisitions { get; set; }

        public string PhoneNumAcquisitions { get; set; }

        public string CatalogAndClass{ get; set; }

        public string NameCatalogAndClass { get; set; }

        public string EmailCatalogAndClass { get; set; }

        public string PhoneNumCatalogAndClass { get; set; }

        public string Reference { get; set; }

        public string NameReference { get; set; }

        public string EmailReference { get; set; }

        public string PhoneNumReference { get; set; }

        public string Circulation { get; set; }

        public string NameCirculation { get; set; }

        public string EmailCirculation { get; set; }

        public string PhoneNumCirculation { get; set; }

        public string Preservation { get; set; }

        public string NamePreservation { get; set; }

        public string EmailPreservation { get; set; }

        public string PhoneNumPreservation { get; set; }

        public string Specialized { get; set; }

        public string NameSpecialized { get; set; }

        public string EmailSpecialized { get; set; }

        public string PhoneNumSpecialized { get; set; }
        #endregion

        #region Questions
        public string Q1 { get; set; }

        public string NameQ1 { get; set; }

        public string EmailQ1 { get; set; }

        public string PhoneNumQ1 { get; set; }

        public string Q2 { get; set; }

        public string NameQ2 { get; set; }

        public string EmailQ2 { get; set; }

        public string PhoneNumQ2 { get; set; }

        public string Q3 { get; set; }

        public string NameQ3 { get; set; }

        public string EmailQ3 { get; set; }

        public string PhoneNumQ3 { get; set; }

        public string Q4 { get; set; }

        public string NameQ4 { get; set; }

        public string EmailQ4 { get; set; }

        public string PhoneNumQ4 { get; set; }

        public string Q5 { get; set; }

        public string NameQ5 { get; set; }

        public string EmailQ5 { get; set; }

        public string PhoneNumQ5 { get; set; }

        public string Q6 { get; set; }

        public string NameQ6 { get; set; }

        public string EmailQ6 { get; set; }

        public string PhoneNumQ6 { get; set; }

        public string Q7 { get; set; }

        public string NameQ7 { get; set; }

        public string EmailQ7 { get; set; }

        public string PhoneNumQ7 { get; set; }

        public string Q8 { get; set; }

        public string NameQ8 { get; set; }

        public string EmailQ8 { get; set; }

        public string PhoneNumQ8 { get; set; }
        #endregion

        #region Upload
        HttpPostedFileBase ResumeUpload { get; set; }
        #endregion

        #region Sign
        public bool isCertified { get; set; }

        public string Signature { get; set; }

        public string Date { get; set; }
        #endregion
    }
}
