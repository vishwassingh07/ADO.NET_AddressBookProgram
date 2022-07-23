using System;
namespace ADO.NET_AddressBookProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Adress Book Program With ADO.NET ");
            AddressBookRepository repository = new AddressBookRepository(); 
            bool end = true;
            Console.WriteLine("1. Create DataBase For AddressBook\n2. End The Program");
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