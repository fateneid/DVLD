using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {

        public static bool GetPersonByID(int PersonID, ref int NationalityCountryID, ref string NationalNo, 
            ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref short Gender, ref string Address, ref string Email, ref string Phone,
            ref string ImagePath, ref DateTime DateOfBirth)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) 
                {
                    isFound = true;

                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] as string ?? "";
                    LastName = (string)reader["LastName"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Email = reader["Email"] as string ?? "";
                    Phone = (string)reader["Phone"];
                    ImagePath = reader["ImagePath"] as string ?? "";                  
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            { 
                connection.Close();
            }

            return isFound;

        }

        public static bool GetPersonByNationalNo(ref int PersonID, ref int NationalityCountryID, string NationalNo,
            ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref short Gender, ref string Address, ref string Email, ref string Phone,
            ref string ImagePath, ref DateTime DateOfBirth)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] as string ?? "";
                    LastName = (string)reader["LastName"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Email = reader["Email"] as string ?? "";
                    Phone = (string)reader["Phone"];
                    ImagePath = reader["ImagePath"] as string ?? "";
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static int AddNewPerson(int NationalityCountryID, string NationalNo,
            string FirstName, string SecondName, string ThirdName, string LastName,
            short Gender, string Address, string Email, string Phone,
            string ImagePath, DateTime DateOfBirth)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People (NationalityCountryID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                 Gender, Address, Email, Phone, ImagePath, DateOfBirth)
                             VALUES (@NationalityCountryID, @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,
                                     @Gender, @Address, @Email, @Phone, @ImagePath, @DateOfBirth);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    PersonID = insertedID;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return PersonID;

        }

        public static bool UpdatePerson(int PersonID, int NationalityCountryID, string NationalNo,
            string FirstName, string SecondName, string ThirdName, string LastName,
            short Gender, string Address, string Email, string Phone,
            string ImagePath, DateTime DateOfBirth)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE People  
                             SET NationalityCountryID = @NationalityCountryID, 
                                 NationalNo = @NationalNo, 
                                 FirstName = @FirstName, 
                                 SecondName = @SecondName, 
                                 ThirdName = @ThirdName, 
                                 LastName = @LastName,
                                 Gender = @Gender,
                                 Address = @Address,
								 Email = @Email,
								 Phone = @Phone,
								 ImagePath = @ImagePath,
								 DateOfBirth = @DateOfBirth
                                 WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE People 
                             WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo, 
                                    People.FirstName, People.SecondName, People.ThirdName, People.LastName,
                                    People.Gender, 
	                                CASE 
	                                WHEN People.Gender = 0 THEN 'Male'
	                                ELSE 'Female'
	                                END AS GenderCaption,
                                    People.DateOfBirth, People.NationalityCountryID, Countries.CountryName,
	                                People.Address, People.Phone, People.Email, People.ImagePath
                             FROM   People INNER JOIN
                                    Countries ON People.NationalityCountryID = Countries.CountryID
                             ORDER BY People.FirstName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                isFound = Convert.ToInt32(command.ExecuteScalar() ?? 0) > 0;

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                isFound = Convert.ToInt32(command.ExecuteScalar() ?? 0) > 0;

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


    }
}
