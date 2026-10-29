using DVLD_DataAccess;
using System;
using System.Data;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason {FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4};

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClassID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public decimal PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public int CreatedByUserID { set; get; }

        public string IssueReasonText
        {
            get { return GetIssueReasonText(this.IssueReason); }
        }
        public bool IsExpired
        {
            get { return this.ExpirationDate < DateTime.Now; }
        }
        public bool IsDetained
        {
            get { return false; }//
        }

        public clsApplication Application;
        public clsDriver Driver;
        public clsLicenseClass LicenseClass;
        public clsUser User;

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        private clsLicense(int LicenseID, int ApplicationID, int DriverID,
            int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes,
            decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.Application = clsApplication.Find(ApplicationID);
            this.Driver = clsDriver.Find(DriverID);
            this.LicenseClass = clsLicenseClass.Find(LicenseClassID);
            this.User = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            int IssueReason = (int)enIssueReason.FirstTime;

            if (clsLicenseData.GetByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, 
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                    ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicenseData.AddNew(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, 
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }
        private bool _Update()
        {
            return clsLicenseData.Update(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, 
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, (int)this.IssueReason, this.CreatedByUserID);
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
        public static bool Delete(int LicenseID)
        {
            return clsLicenseData.Delete(LicenseID);
        }

        public static DataTable GetAll()
        {
            return clsLicenseData.GetAll();
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public static bool IsExist(int LicenseID)
        {
            return clsLicenseData.IsExist(LicenseID);
        }

        public static int GetActiveByPersonIDAndClassID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveByPersonIDAndClassID(PersonID, LicenseClassID);
        }
        public static bool HasActiveByPersonIDAndClassID(int PersonID, int LicenseClassID)
        {
            return GetActiveByPersonIDAndClassID(PersonID, LicenseClassID) != -1;
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "Unknown";
            }
        }

        public bool Deactivate()
        {
            return clsLicenseData.Deactivate(this.LicenseID);
        }

        public bool CanRenew()
        {
            return IsActive && ExpirationDate <= DateTime.Now.AddDays(30);
        }
        public clsLicense Renew(string Notes, int CreatedByUserID)
        {
            // Validations
            if (!CanRenew()) return null;

            // Create Application
            clsApplication RenewApp = new clsApplication();
            RenewApp.ApplicationTypeID = enApplicationType.RenewLicense;
            RenewApp.ApplicantPersonID = this.Driver.PersonID;
            RenewApp.ApplicationStatus = enApplicationStatus.Completed;
            RenewApp.PaidFees = clsApplicationType.Find((int)enApplicationType.RenewLicense).ApplicationFees;
            RenewApp.CreatedByUserID = CreatedByUserID;

            if (!RenewApp.Save()) return null;

            // Issue New License
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = RenewApp.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.ExpirationDate = NewLicense.IssueDate.AddYears(this.LicenseClass.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = clsLicenseClass.Find(this.LicenseClassID).ClassFees;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save()) return null;

            // Deactivate Old License
            Deactivate();

            return NewLicense;
        }

    }
}
