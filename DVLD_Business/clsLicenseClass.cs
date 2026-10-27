using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicenseClass
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public decimal ClassFees { set; get; }
        public byte DefaultValidityLength { set; get; }
        public byte MinimumAllowedAge { set; get; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.ClassFees = 0;
            this.DefaultValidityLength = 10;
            this.MinimumAllowedAge = 18;

            this.Mode = enMode.AddNew;

        }
        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            decimal ClassFees, byte DefaultValidityLength, byte MinimumAllowedAge)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.ClassFees = ClassFees;
            this.DefaultValidityLength = DefaultValidityLength;
            this.MinimumAllowedAge = MinimumAllowedAge;

            this.Mode = enMode.Update;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            decimal ClassFees = 0;
            byte DefaultValidityLength = 10, MinimumAllowedAge = 18;

            if (clsLicenseClassData.GetByID(LicenseClassID, ref ClassName, ref ClassDescription, 
                ref ClassFees, ref DefaultValidityLength, ref MinimumAllowedAge))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                    ClassFees, DefaultValidityLength, MinimumAllowedAge);
            else
                return null;
        }
        public static clsLicenseClass Find(string ClassName)
        {
            string ClassDescription = "";
            decimal ClassFees = 0;
            byte DefaultValidityLength = 10, MinimumAllowedAge = 18;
            int LicenseClassID = -1;

            if (clsLicenseClassData.GetByClassName(ClassName, ref LicenseClassID, ref ClassDescription,
                ref ClassFees, ref DefaultValidityLength, ref MinimumAllowedAge))
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                    ClassFees, DefaultValidityLength, MinimumAllowedAge);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.LicenseClassID = clsLicenseClassData.AddNew(this.ClassName, this.ClassDescription, 
                                  this.ClassFees, this.DefaultValidityLength, this.MinimumAllowedAge);

            return (this.LicenseClassID != -1);
        }
        private bool _Update()
        {
            return clsLicenseClassData.Update(this.LicenseClassID, this.ClassName, this.ClassDescription,
                                  this.ClassFees, this.DefaultValidityLength, this.MinimumAllowedAge);
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

        public static DataTable GetAll()
        {
            return clsLicenseClassData.GetAll();
        }


    }
}
