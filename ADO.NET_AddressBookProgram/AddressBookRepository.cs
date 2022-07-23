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
        public void CreateAddressBookDataBase()
        {
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=AddressBook_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                SqlCommand command = new SqlCommand("Create DataBase AddressBookAdo", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DataBase For AddressBook Created");
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
