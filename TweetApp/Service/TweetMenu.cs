using System;

namespace TweetApp.Service
{
    public class TweetMenu
    {
        private LoggedUser logged = new();

        public void PostLoggedMenu(int userID)
        {

            bool valid = true;
            while (valid)
            {

                Console.WriteLine("\n Please select a prefferable option:");
                Console.WriteLine("1. Post A Tweets");
                Console.WriteLine("2. View My Tweets");
                Console.WriteLine("3. View All Tweets");
                Console.WriteLine("4. View All Users");
                Console.WriteLine("5. Reset Password ");
                Console.WriteLine("6. Logout ");

                LoggedMenu menu = new LoggedMenu();
                string b = Console.ReadLine();
                bool a = int.TryParse(b, out int option);
                //Console.WriteLine(option);
                switch (option)
                {
                    case 1:
                        menu.Post(userID);
                        break;

                    case 2:
                        menu.MyTweet(userID);
                        break;

                    case 3:
                        menu.AllTweet();
                        break;

                    case 4:
                        menu.AllUsers();
                        break;
                    case 5:
                        menu.ResetPassword(userID);
                        break;

                    case 6:
                        logged.Logout(userID);
                        Console.WriteLine("You have successfully logged out!!!");
                        valid = false;
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }
            }

        }
    }
}
