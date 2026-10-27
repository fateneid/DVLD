using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {

        public static bool GetByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
            ref decimal ClassFees, ref byte DefaultValidityLength, ref byte MinimumAllowedAge)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try 
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = reader["ClassDescription"] as string ?? "";
                    ClassFees = (decimal)reader["ClassFees"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];

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

        public static bool GetByClassName(string ClassName, ref int LicenseClassID, ref string ClassDescription,
            ref decimal ClassFees, ref byte DefaultValidityLength, ref byte MinimumAllowedAge)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = reader["ClassDescription"] as string ?? "";
                    ClassFees = (decimal)reader["ClassFees"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //throw;
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static int AddNew(string ClassName, string ClassDescription, decimal ClassFees,
            byte DefaultValidityLength, byte MinimumAllowedAge)
        {

            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LicenseClasses (ClassName, ClassDescription, 
                                         ClassFees, DefaultValidityLength, MinimumAllowedAge)
                             VALUES (@ClassName, @ClassDescription, @ClassFees,
                                     @DefaultValidityLength, @MinimumAllowedAge);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    LicenseClassID = insertedID;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return LicenseClassID;

        }

        public static bool Update(int LicenseClassID, string ClassName, string ClassDescription, 
            decimal ClassFees, byte DefaultValidityLength, byte MinimumAllowedAge)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LicenseClasses  
                             SET ClassName = @ClassName, 
                                 ClassDescription = @ClassDescription,
                                 ClassFees = @ClassFees,
                                 DefaultValidityLength = @DefaultValidityLength,
                                 MinimumAllowedAge = @MinimumAllowedAge
                                 WHERE LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }

        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses 
                             ORDER BY LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }


    }
}
