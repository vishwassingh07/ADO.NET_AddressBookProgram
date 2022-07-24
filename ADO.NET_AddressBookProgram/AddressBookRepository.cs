using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_AddressBookProgram
{
    public class AddressBookRepository
    {
        /// <summary>
        /// UC1- Creating Database For AddressBook
        /// </summary>
        public void CreateAddressBookDataBase()
        {
            try
            {
                //Giving Path For Connection
                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=AddressBook_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //Opening Connection
                connection.Open();
                //Representing Connection To SQL Server DataBase
                SqlCommand command = new SqlCommand("Create DataBase AddressBookAdo", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DataBase For AddressBook Created");
                //Closing Connection
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// UC2- Creating Table For AddressBook DataBase
        /// </summary>
        public void CreateTableInAddressBook()
        {
            try
            {
                //Giving Path For Connection
                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=AddressBookAdo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //Opening Connection
                connection.Open();
                //Representing Connection To SQL Server DataBase
                SqlCommand command = new SqlCommand("Create Table AddressBookADO(Id int identity(1, 1) Primary Key,FirstName varchar(200),LastName varchar(200),Address varchar(300),City varchar(100),State varchar(50),Zip int,PhoneNumber bigint,Email varchar(200));",connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Address Book ADO Table Created Successfully ");
                //Closing Connection
                connection.Close ();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public const string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=AddressBookAdo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = null;
        //Opening Connection";

        /// <summary>
        /// Inserting Contact Into AddressBook
        /// </summary>
        /// <param name="model"></param>
        public void InsertContactInAddressBook(AddressBookModel model)
        {
            try
            {
                //Giving Path For Connection
                using (connection = new SqlConnection(connectionString))
                {
                    //Representing Connection To SQL Server DataBase
                    SqlCommand command = new SqlCommand("spAddressBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    //Opening Connection
                    connection.Open ();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Contact Details Successfully Added To The Table");
                    }
                    else
                    {
                        Console.WriteLine("Contact Details Could Not Be Inserted");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// UC4 - Updating Existing Contact In AddressBook
        /// </summary>
        /// <param name="model"></param>
        public void UpdateContactInAddressBook(AddressBookModel model)
        {
            try
            {
                //Giving Path For Connection
                connection = new SqlConnection(connectionString);
                //Representing Connection To SQL Server DataBase
                SqlCommand command = new SqlCommand("spUpdateContactDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("City", model.City);
                command.Parameters.AddWithValue("State", model.State);
                //Opening Connection
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Contact Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Couldn't Update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Finally Block To Initialize The Garbage Collector
            finally
            {
                //Closing The Connection
                connection.Close ();
            }
        }
        /// <summary>
        /// UC5 - Deleting Contact From AddressBook
        /// </summary>
        /// <param name="model"></param>
        public void DeleteContactFromAddressBook(AddressBookModel model)
        {
            try
            {
                //Giving Path For Connection
                connection = new SqlConnection(connectionString);
                //Representing Connection To SQL Server DataBase
                SqlCommand command = new SqlCommand("spDeleteConact", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                //Opening Connection
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Successfully Deleted Contact Details");
                }
                else
                {
                    Console.WriteLine("Could Not Delete");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Finally Block To Initialize The Garbage Collector
            finally
            {
                //Closing The Connection
                connection.Close();
            }
        }
        /// <summary>
        /// UC6- Retrieve Contact By City And State
        /// </summary>
        /// <param name="model"></param>
        public void RetriveContactByCityOrState(AddressBookModel model)
        {
            try
            {
                //Giving Path For Connection
                connection = new SqlConnection(connectionString);
                //Representing Connection To SQL Server DataBase
                string query = "Select * From AddressBookAdo Where City = 'Chennai' And State = 'Tamilnadu';";
                SqlCommand command = new SqlCommand(query , connection);
                //Opening Connection
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.ID = Convert.ToInt32(reader["ID"] == DBNull.Value ? default : reader["ID"]);
                        model.FirstName = Convert.ToString(reader["FirstName"] == DBNull.Value ? default : reader["FirstName"]);
                        model.LastName = Convert.ToString(reader["LastName"] == DBNull.Value ? default : reader["LastName"]);
                        model.Address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
                        model.City = Convert.ToString(reader["City"] == DBNull.Value ? default : reader["City"]);
                        model.State = Convert.ToString(reader["State"] == DBNull.Value ? default : reader["State"]);
                        model.Zip = Convert.ToInt32(reader["Zip"] == DBNull.Value ? default : reader["Zip"]);
                        model.PhoneNumber = Convert.ToInt64(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        model.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}" , model.ID, model.FirstName, model.LastName, model.Address
                            ,model.City,model.State, model.Zip, model.PhoneNumber, model.Email);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Closing Connection
                connection.Close();
            }
        }
    }
}
