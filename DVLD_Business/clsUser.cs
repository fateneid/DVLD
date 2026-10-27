using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update  = 1};
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public clsPerson Person;

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;

            Mode = enMode.AddNew;
        }
        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            this.Person = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = true;

            if (clsUserData.GetByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else 
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = true;

            if (clsUserData.GetByUsernameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.UserID = clsUserData.AddNew(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }
        private bool _Update()
        {
            return clsUserData.Update(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool ChangePassword(string NewPassword)
        {
            if(!clsUserData.ChangePassword(this.UserID, Password)) return false;

            this.Password = NewPassword;
            return true;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
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
        public static bool Delete(int UserID)
        {
            return clsUserData.Delete(UserID);
        }

        public static DataTable GetAll()
        {
            return clsUserData.GetAll();
        }

        public static bool IsExist(int UserID)
        {
            return clsUserData.IsExist(UserID);
        }
        public static bool IsExist(string UserName)
        {
            return clsUserData.IsExist(UserName);
        }
        public static bool IsExistByPersonID(int PersonID)
        {
            return clsUserData.IsExistByPersonID(PersonID);
        }

    }
}
