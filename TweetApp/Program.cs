using System;
using TweetApp.Service;

namespace TweetApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            PreLogIn user = new PreLogIn();
            bool menu = true;
            while (menu)
            {
                string title = @"
 _      _____ _     ____  ____  _      _____   _____  ____    _____  _      _____ _____ _____ 
/ \  /|/  __// \   /   _\/  _ \/ \__/|/  __/  /__ __\/  _ \  /__ __\/ \  /|/  __//  __//__ __\
| |  |||  \  | |   |  /  | / \|| |\/|||  \      / \  | / \|    / \  | |  |||  \  |  \    / \  
| |/\|||  /_ | |_/\|  \_ | \_/|| |  |||  /_     | |  | \_/|    | |  | |/\|||  /_ |  /_   | |  
\_/  \|\____\\____/\____/\____/\_/  \|\____\    \_/  \____/    \_/  \_/  \|\____\\____\  \_/  
                                                                                              ";
                Console.WriteLine(title);
                Console.WriteLine("Please enter a option of your Choice:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Forgot Password");
                Console.WriteLine("4. Exit");
                string b = Console.ReadLine();
                bool a = int.TryParse(b, out int option);

                switch (option)
                {
                    case 1:
                        user.Register();
                        break;

                    case 2:
                        user.LogIn();
                        break;

                    case 3:
                        user.ForgetPassword();
                        break;
                    case 4:
                        menu = false;
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Please choose a vaild option.");
                        break;

                }
            }
        }
    }
}
