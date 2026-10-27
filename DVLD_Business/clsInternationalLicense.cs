using DVLD_DataAccess;
using System;
using System.Data;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }
        public int CreatedByUserID { set; get; }

        public clsApplication Application;
        public clsDriver Driver;
        public clsLicense LocalLicense;
        public clsUser User;

        private clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.Application = clsApplication.Find(ApplicationID);
            this.Driver = clsDriver.Find(DriverID);
            this.LocalLicense = clsLicense.Find(IssuedUsingLocalLicenseID);
            this.User = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = true;

            if (clsInternationalLicenseData.GetByID(InternationalLicenseID, ref ApplicationID, ref DriverID, 
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, 
                    IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }
        public static clsInternationalLicense FindByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1, ApplicationID = -1, DriverID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = true;

            if (clsInternationalLicenseData.GetByLocalLicenseID(ref InternationalLicenseID, ref ApplicationID, ref DriverID,
                LocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                    LocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNew(this.ApplicationID, this.DriverID, 
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }
        private bool _Update()
        {
            return clsInternationalLicenseData.Update(this.InternationalLicenseID, this.ApplicationID, this.DriverID, 
                this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();
            }

            return false;
        }
        public static bool Delete(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.Delete(InternationalLicenseID);
        }

        public static DataTable GetAll()
        {
            return clsInternationalLicenseData.GetAll();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverLicenses(DriverID);
        }

        public static bool IsExist(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.IsExist(InternationalLicenseID);
        }

        public static int GetActiveByLocalLicenseID(int LocalLicenseID)
        {
            return clsInternationalLicenseData.GetActiveByLocalLicenseID(LocalLicenseID);
        }
        public static bool HasActiveByLocalLicenseID(int LocalLicenseID)
        {
            return GetActiveByLocalLicenseID(LocalLicenseID) != -1;
        }
        public static bool CanIssueInternationalLicense(clsLicense LocalLicense)
        {
            if (LocalLicense == null) return false;
            if (LocalLicense.IsExpired) return false;
            if (!LocalLicense.IsActive) return false;
            if (LocalLicense.IsDetained) return false;
            if (LocalLicense.LicenseClassID != 3) return false;

            return true;
        }
        public static clsInternationalLicense IssueInternationalLicense(int LocalLicenseID, int CreatedByUserID)
        {
            // Validations
            if (HasActiveByLocalLicenseID(LocalLicenseID)) return null;

            clsLicense LocalLicense = clsLicense.Find(LocalLicenseID);
            if (!CanIssueInternationalLicense(LocalLicense)) return null;

            // Create Application
            clsApplication Application = new clsApplication();
            Application.ApplicationTypeID = enApplicationType.NewInternationalLicense;
            Application.ApplicantPersonID = LocalLicense.Driver.PersonID;
            Application.ApplicationStatus = enApplicationStatus.Completed;
            Application.PaidFees = clsApplicationType.Find((int)enApplicationType.NewInternationalLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save()) return null;

            // Issue International License
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            InternationalLicense.ApplicationID = Application.ApplicationID;
            InternationalLicense.DriverID = LocalLicense.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = LocalLicenseID;
            InternationalLicense.ExpirationDate = InternationalLicense.IssueDate.AddYears(1);
            InternationalLicense.CreatedByUserID = CreatedByUserID;

            if (!InternationalLicense.Save()) return null;

            return InternationalLicense;
        }

    }
}
