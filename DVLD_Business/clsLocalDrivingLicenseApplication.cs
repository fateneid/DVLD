using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }

        public clsLicenseClass LicenseClass;

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            ApplicationTypeID = enApplicationType.NewLocalLicense;
            PaidFees = clsApplicationType.Find((int)ApplicationTypeID).ApplicationFees;

        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID,
            int ApplicationID, enApplicationType ApplicationTypeID,
            int ApplicantPersonID, enApplicationStatus ApplicationStatus, DateTime ApplicationDate,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID) :
            base(ApplicationID, ApplicationTypeID, ApplicantPersonID, ApplicationStatus, 
                   ApplicationDate, LastStatusDate, PaidFees, CreatedByUserID)
        {

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;

            this.LicenseClass = clsLicenseClass.Find(LicenseClassID);

        }

        public new static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = -1, ApplicationID = -1;

            if (clsLocalDrivingLicenseApplicationData.GetByID(LocalDrivingLicenseApplicationID, ref LicenseClassID, ref ApplicationID)) 
            {
                clsApplication app = clsApplication.Find(ApplicationID);
                if (app == null) return null;

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID,
                    app.ApplicationID, app.ApplicationTypeID, app.ApplicantPersonID, app.ApplicationStatus,
                    app.ApplicationDate, app.LastStatusDate, app.PaidFees, app.CreatedByUserID);
            }
            else
                return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.GetByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
            {
                clsApplication app = clsApplication.Find(ApplicationID);
                if (app == null) return null;

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID,
                    app.ApplicationID, app.ApplicationTypeID, app.ApplicantPersonID, app.ApplicationStatus,
                    app.ApplicationDate, app.LastStatusDate, app.PaidFees, app.CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = 
                clsLocalDrivingLicenseApplicationData.AddNew(this.LicenseClassID, base.ApplicationID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.Update(this.LocalDrivingLicenseApplicationID,
                this.LicenseClassID, base.ApplicationID);
        }

        public new bool Save()
        {
            enMode CurrentMode = Mode;

            if (!base.Save()) return false;        

            switch (CurrentMode)
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
        public new bool Delete()
        {
            if (!clsLocalDrivingLicenseApplicationData.Delete(this.LocalDrivingLicenseApplicationID))
                return false;

            return base.Delete();

        }

        public new static DataTable GetAll()
        {
            return clsLocalDrivingLicenseApplicationData.GetAll();
        }

        public new static bool IsExist(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.IsExist(LocalDrivingLicenseApplicationID);
        }

        public static bool DoesPersonHaveActiveApplicationForThisClass(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPersonHaveActiveApplicationForThisClass(PersonID, LicenseClassID);
        }

        public static bool IsPersonEligibleForLicenseClass(int PersonID, int LicenseClassID) 
        {
            clsPerson Person = clsPerson.Find(PersonID);
            clsLicenseClass LicenseClass = clsLicenseClass.Find(LicenseClassID);

            if (Person == null || LicenseClass == null) return false;

            return Person.Age >= LicenseClass.MinimumAllowedAge;

        }

        public int GetActiveLicenseID()
        {
            return clsLicenseData.GetActiveByPersonIDAndClassID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public bool IsLicenseIssued()
        {
            return GetActiveLicenseID() != -1;
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (!Driver.Save()) return -1;
            }

            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = Driver.DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.ExpirationDate = License.IssueDate.AddYears(this.LicenseClass.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClass.ClassFees;
            License.CreatedByUserID = CreatedByUserID;

            if (!License.Save()) return -1;

            if (!ChangeStatus(enApplicationStatus.Completed)) return -1;

            return License.LicenseID;

        }

        public bool HasTakenTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.HasTakenTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public byte GetPassedTestsCount()
        {
            return clsLocalDrivingLicenseApplicationData.GetPassedTestsCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool PassedAllTests()
        {
            return GetPassedTestsCount() == 3;
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }


    }
}
