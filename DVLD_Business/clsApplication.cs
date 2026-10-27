using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3};
        public enum enApplicationType { NewLocalLicense = 1, RenewLicense = 2,
            ReplaceLostLicense = 3, ReplaceDamagedLicense = 4, ReleaseDetainedLicense = 5,
            NewInternationalLicense = 6, RetakeTest = 7};

        public int ApplicationID { set; get; }
        public enApplicationType ApplicationTypeID { set; get; }
        public int ApplicantPersonID { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }
        public DateTime ApplicationDate { set; get; }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public clsApplicationType ApplicationType;
        public clsPerson Person;
        public clsUser User;

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicationTypeID = enApplicationType.NewLocalLicense;
            this.ApplicantPersonID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        protected clsApplication(int ApplicationID, enApplicationType ApplicationTypeID,
            int ApplicantPersonID, enApplicationStatus ApplicationStatus, DateTime ApplicationDate,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.ApplicationType = clsApplicationType.Find((int)ApplicationTypeID);
            this.Person = clsPerson.Find(ApplicantPersonID);
            this.User = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = -1, CreatedByUserID = -1;
            int ApplicationTypeID = (int)enApplicationType.NewLocalLicense;
            int ApplicationStatus = (int)enApplicationStatus.New;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;

            if (clsApplicationData.GetByID(ApplicationID, ref ApplicationTypeID,
            ref ApplicantPersonID, ref ApplicationStatus, ref ApplicationDate,
            ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicationID, (enApplicationType)ApplicationTypeID, ApplicantPersonID, 
                    (enApplicationStatus)ApplicationStatus, ApplicationDate, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationData.AddNew((int)this.ApplicationTypeID, this.ApplicantPersonID,
                    (int)this.ApplicationStatus, this.ApplicationDate, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }
        private bool _Update()
        {
            return clsApplicationData.Update(this.ApplicationID, (int)this.ApplicationTypeID, this.ApplicantPersonID,
                    (int)this.ApplicationStatus, this.ApplicationDate, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool ChangeStatus(enApplicationStatus ApplicationStatus)
        {
            DateTime LastStatusDate = DateTime.Now;

            if (!clsApplicationData.ChangeStatus(this.ApplicationID, (int)ApplicationStatus, LastStatusDate)) return false;

            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;

            return true;
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
        public bool Delete()
        {
            return clsApplicationData.Delete(this.ApplicationID);
        }

        public static DataTable GetAll()
        {
            return clsApplicationData.GetAll();
        }

        public static bool IsExist(int ApplicationID)
        {
            return clsApplicationData.IsExist(ApplicationID);
        }


    }
}
