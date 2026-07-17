using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update  = 1};
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public int NationalityCountryID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ThirdName))
                    return $"{FirstName} {SecondName} {LastName}";
                else
                    return $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }
        }
        public short Gender { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string ImagePath { set; get; }
        public DateTime DateOfBirth { set; get; }

        public clsCountry CountryInfo;


        public clsPerson()
        {

            this.PersonID = -1;
            this.NationalityCountryID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gender = 0;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.ImagePath = "";
            this.DateOfBirth = DateTime.Now;

            Mode = enMode.AddNew;

        }

        private clsPerson(int PersonID, int NationalityCountryID, string NationalNo,
            string FirstName, string SecondName, string ThirdName, string LastName,
            short Gender, string Address, string Email, string Phone,
            string ImagePath, DateTime DateOfBirth)
        {
            this.PersonID = PersonID;
            this.NationalityCountryID = NationalityCountryID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;

            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;

        }


        public static clsPerson Find(int PersonID)
        {
            int NationalityCountryID = -1;
            short Gender = 1;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "",
            Address = "", Email = "", Phone = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;

            if (clsPersonData.GetPersonByID(PersonID, ref NationalityCountryID, ref NationalNo,
            ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Gender, ref Address, ref Email,
            ref Phone, ref ImagePath, ref DateOfBirth))
                return new clsPerson(PersonID, NationalityCountryID, NationalNo,
            FirstName, SecondName, ThirdName, LastName, Gender, Address, Email, Phone,
            ImagePath, DateOfBirth);

            else 
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1, NationalityCountryID = -1;
            short Gender = 1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
            Address = "", Email = "", Phone = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;

            if (clsPersonData.GetPersonByNationalNo(ref PersonID, ref NationalityCountryID, NationalNo,
            ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Gender, ref Address, ref Email,
            ref Phone, ref ImagePath, ref DateOfBirth))

                return new clsPerson(PersonID, NationalityCountryID, NationalNo,
            FirstName, SecondName, ThirdName, LastName, Gender, Address, Email, Phone,
            ImagePath, DateOfBirth);

            else
                return null;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalityCountryID, this.NationalNo,
            this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gender,
            this.Address, this.Email, this.Phone, this.ImagePath, this.DateOfBirth);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalityCountryID, this.NationalNo,
            this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gender,
            this.Address, this.Email, this.Phone, this.ImagePath, this.DateOfBirth);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                     return _UpdatePerson();             
            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            clsPerson Person = Find(PersonID);

            if (Person == null) return false;

            if (!clsPersonData.DeletePerson(PersonID)) return false;

            clsImageHelper.DeleteImage(Person.ImagePath);
            return true;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }


    }
}
