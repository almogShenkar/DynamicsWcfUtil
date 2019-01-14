using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Option
    {
        Create=1,Delete,Update,Get
    }

    class MyMenu
    {

        private AccountService.AccountServiceClient _obj;

        public MyMenu()
        {
            Console.WriteLine("Welcome to account service consume util!");
            _obj = new AccountService.AccountServiceClient("NetTcpBinding_IAccountService");
            do
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1 = Create ");
                Console.WriteLine("2 = Delete ");
                Console.WriteLine("3 = Update ");
                Console.WriteLine("4 = Get ");
                Console.WriteLine();
                var numSelection = Console.ReadLine();
                if (numSelection != null && !numSelection.Equals(""))
                {
                    Option result = (Option)Enum.Parse(typeof(Option), numSelection);
                    switch (result)
                    {
                        case Option.Create:
                            {
                                Create();
                                break;
                            }
                        case Option.Delete:
                            {
                                Delete();
                                break;
                            }
                        case Option.Update:
                            {
                                Update();
                                break;
                            }
                        case Option.Get:
                            {
                                Get();
                                break;
                            }
                        default: break;
                    }
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("Continue?  y\\n");
                    var isContinue = Console.ReadLine();
                    if (isContinue.Equals("n")) break;
                    
                }

            } while (true);
        }

        private void Delete()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Enter account email to delete:");
            var email = Console.ReadLine();
            Console.WriteLine("Result: " + _obj.DeleteAccountByEmail(email));


        }

        private void Update()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Enter account email:");
            var email = Console.ReadLine();
            Console.WriteLine("Enter account new phone:");
            var phone = Console.ReadLine();
            Console.WriteLine("Result: " + _obj.UpdatePhoneByEmail(email, phone));
        }

        private void Get()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.Write("Enter email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Result: " + _obj.GetAccountByEmail(email));

        }

        private void Create()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.Write("Enter firstname: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter lastname: ");
            var lastname = Console.ReadLine();
            Console.Write("Enter email: ");
            var email = Console.ReadLine();
            Console.Write("Enter phone: ");
            var phone = Console.ReadLine();
            Console.WriteLine("Result: " + _obj.CreateAccount(firstName, lastname, email, phone));

        }
    }
}
