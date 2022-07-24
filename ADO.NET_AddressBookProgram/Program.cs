using System;
namespace ADO.NET_AddressBookProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Adress Book Program With ADO.NET ");
            AddressBookRepository repository = new AddressBookRepository();
            AddressBookModel model = new AddressBookModel();
            bool end = true;
            Console.WriteLine("1. Create DataBase For AddressBook\n2. Create Table For AddressBook\n3." +
                " Insert Contact Details In The Table\n4. Update Contact Details\n5. Delete Contact Details\n6. End The Program");
            while (true)
            {
                Console.WriteLine("Choose an option to execute :");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        repository.CreateAddressBookDataBase();
                        break;
                    case 2:
                        repository.CreateTableInAddressBook();
                        break;
                    case 3:
                        AddressBookModel insert = new AddressBookModel();
                        insert.FirstName = "Vishwas";
                        insert.LastName = "Singh";
                        insert.Address = "Marathalli";
                        insert.City = "Bangalore";
                        insert.State = "Karnataka";
                        insert.Zip = 560066;
                        insert.PhoneNumber = 947856314;
                        insert.Email = "baghel@gmail.com";
                        repository.InsertContactInAddressBook(insert);
                        break;
                    case 4:
                        model.FirstName = "Siddhant";
                        model.City = "Chennai";
                        model.State = "Tamilnadu";
                        repository.UpdateContactInAddressBook(model);
                        break;
                    case 5:
                        model.FirstName = "Shobhit";
                        repository.DeleteContactFromAddressBook(model);
                        break;
                    case 6:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Option");
                        break;
                }
            }
        }
    }
}