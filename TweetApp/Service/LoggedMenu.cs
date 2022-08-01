using System;
using TweetApp.Model;
using TweetApp.Repository;

namespace TweetApp.Service
{
    public class LoggedMenu
    {
        private TweetPostRepository tweetPost = new TweetPostRepository();
        private UserRepository userRepository = new UserRepository();
        private PreLogIn login = new PreLogIn();

        public void Post(int userID)
        {
            Console.WriteLine("Give me a Caption: ");
            string caption = Console.ReadLine();
            Console.WriteLine("Write you opinion: ");
            string body = Console.ReadLine();
            if (string.IsNullOrEmpty(body))
            {
                Console.WriteLine("Please write something!!");
            }
            TweetPost post = new TweetPost
            {
                PostBody = body,
                Caption = caption,
                PostedBy = userID,
                PostedOn = DateTime.Now.ToString()

            };
            TweetPostRepository tweets = new TweetPostRepository();
            try
            {
                bool resul = tweets.PostTweet(post);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void MyTweet(int userID)
        {
            var listTweet = tweetPost.GetMyTweet(userID);
            Console.WriteLine($"{listTweet[0].Username}'s tweets are: \n");
            try
            {
                //var listTweet = tweetPost.GetMyTweet(userID);
                if (listTweet != null)
                {
                    foreach (var tweet in listTweet)
                    {
                        Console.WriteLine($"{tweet.Caption} - {tweet.PostBody} posted on {tweet.PostedOn} \n");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing Found");
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void AllTweet()
        {
            Console.WriteLine("Viewing all tweets \n");
            try
            {
                var listTweet = tweetPost.GetAllTweet();
                if (listTweet != null)
                {
                    foreach (var tweet in listTweet)
                    {
                        Console.WriteLine($"{tweet.Caption} - {tweet.PostBody} posted by {tweet.Username} on {tweet.PostedOn} \n");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AllUsers()
        {
            Console.WriteLine("All Users are there: \n");
            try
            {
                var users = tweetPost.GetAllUsers();
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.UserId} || {user.UserName} || {user.Email} || {user.Gender} ");
                    }
                }
                else
                {
                    Console.WriteLine("No User found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ResetPassword(int id)
        {
            int i = 0;
        current: if (i < 3)
            {
                Console.WriteLine("Enter current Password: ");
                string password = Console.ReadLine();
                string username = userRepository.GetuserName(id);
                var user = userRepository.GetUser(username);
                if (user.Password.Equals(password))
                {
                    Console.WriteLine("Enter a new password: ");
                    string pass = Console.ReadLine();
                confirmation: Console.WriteLine("Confirm the Password: ");
                    string cnfPassword = Console.ReadLine();
                    if (cnfPassword != pass)
                    {
                        Console.WriteLine("Password not matching");
                        goto confirmation;
                    }
                    else
                    {

                        if (userRepository.UpdatePassword(id, pass))
                        {
                            Console.WriteLine("Password has reset successfully!");
                            userRepository.UpdateActiveStatusLoggingOut(id);
                        log: Console.WriteLine("Press M/m to login again");
                            Console.WriteLine("E/e for Exit");
                            string option = Console.ReadLine();
                            if (option.Equals("M") || option.Equals("m"))
                            {
                                login.LogIn();
                            }
                            else if (option.Equals("E") || option.Equals("e"))
                            {
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                goto log;
                            }
                        }
                    }
                }
                else
                {
                    if (i < 3)
                    {

                        i++;
                        if (i < 3)
                        {
                            Console.WriteLine("you have " + (3 - i).ToString() + " more attempts left.");
                        }
                        else
                        {
                            Console.WriteLine("You have exhausted all attempts \n");
                        }
                        goto current;
                    }
                }
            }
            else
            {
                Console.WriteLine("please click on Logout and forget password to set your new password");
            }

        }


    }
}
