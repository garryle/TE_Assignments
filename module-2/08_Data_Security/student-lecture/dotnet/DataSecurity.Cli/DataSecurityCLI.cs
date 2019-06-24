using Security.BusinessLogic;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSecurity.Cli
{
    public class DataSecurityCLI
    {
        private const string Option_Login = "1";
        private const string Option_Register = "2";
        private const string Option_Logout = "1";
        private const string Option_Quit = "q";

        private UserManager _userMgr = null;

        public DataSecurityCLI(UserManager userManager)
        {
            _userMgr = userManager;
        }

        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                if (_userMgr.IsAuthenticated)
                {
                    Console.WriteLine(" (1) Logout");
                }
                else
                {
                    Console.WriteLine(" (1) Login");
                    Console.WriteLine(" (2) Register");
                }
                Console.WriteLine(" (Q) Quit");
                Console.Write(" Please make a choice: ");

                string choice = Console.ReadLine().ToLower();

                Console.WriteLine();

                if (_userMgr.IsAuthenticated)
                {
                    if (choice == Option_Logout)
                    {
                        _userMgr.LogoutUser();
                    }
                    else if (choice == Option_Quit)
                    {
                        exit = true;
                    }
                    else
                    {
                        DisplayInvalidOption();
                        Console.ReadKey();
                    }
                }
                else
                {
                    if (choice == Option_Login)
                    {
                        DisplayLogin();
                    }
                    else if (choice == Option_Register)
                    {
                        DisplayRegister();
                    }
                    else if (choice == Option_Quit)
                    {
                        exit = true;
                    }
                    else
                    {
                        DisplayInvalidOption();
                        Console.ReadKey();
                    }
                }
            }
        }

        private void DisplayLogin()
        {
            Console.Clear();
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            try
            {
                _userMgr.LoginUser(username, password);
                Console.WriteLine($"Welcome {_userMgr.User.FirstName} {_userMgr.User.LastName}");
                if(_userMgr.Permission.IsStandardUser)
                {
                    Console.WriteLine("You are a standard user dude.");
                }
                else if(_userMgr.Permission.IsAdministrator)
                {
                    Console.WriteLine("You are an administrator, I want to be you when I grow up.");
                }
                else
                {
                    Console.WriteLine("Get out hacker!!");
                    _userMgr.LogoutUser();
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private void DisplayRegister()
        {
            Console.Clear();

            User user = new User();
            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("Enter password again: ");
            user.ConfirmPassword = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            user.LastName = Console.ReadLine();

            try
            {
                _userMgr.RegisterUser(user);
                Console.WriteLine($"Welcome {_userMgr.User.FirstName} {_userMgr.User.LastName}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private void DisplayInvalidOption()
        {
            Console.WriteLine(" The option you selected is not a valid option.");
            Console.WriteLine();
        }
    }
}
