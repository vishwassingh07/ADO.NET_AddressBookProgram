using System;
using System.Collections.Generic;
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
                SqlCommand command = new SqlCommand("Create Table AddressBookADO(Id int identity(1, 1) Primary Key,FirstName varchar(200),LastName varchar(200),Address varchar(300),City varchar(100),State varchar(50),Zip int,Phone bigint,Email varchar(200));",connection);
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
    }
}
