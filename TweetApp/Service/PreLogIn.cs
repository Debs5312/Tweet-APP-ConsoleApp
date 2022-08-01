using System;
using System.Linq;
using System.Text.RegularExpressions;
using TweetApp.DBContext;
using TweetApp.Model;
using TweetApp.Repository;

namespace TweetApp.Service
{
    internal class PreLogIn
    {
        private TweetContext context = new();
        private LoggedUser logged = new();
        private UserRepository userRepository = new UserRepository();
        private TweetMenu menu = new TweetMenu();
        public void Register()
        {
            Console.WriteLine("Register");
        email: Console.WriteLine("Enter Your email: ");
            string Email = Console.ReadLine();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (!string.IsNullOrEmpty(Email) && match.Success)
            {
                var existingUser = userRepository.GetUser(userName: null, Email: Email);
                if (existingUser != null)
                {
                    Console.WriteLine("This email has been already register!");
                    return;
                }
                else
                {
                password: Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    if (!String.IsNullOrEmpty(password))
                    {
                    hello: Console.WriteLine("Confirm the Password: ");
                        string cnfPassword = Console.ReadLine();
                        if (cnfPassword != password)
                        {
                            Console.WriteLine("Password not matching");
                            goto hello;
                        }
                        Console.WriteLine("Gender (M/F): ");
                        string gen = Console.ReadLine();


                        UserDetails userDetails = new UserDetails
                        {

                            Email = Email.ToString(),
                            Password = cnfPassword.ToString(),
                            UserName = Email.Split('@')[0].ToString(),
                            Gender = gen.ToString()
                        };


                        bool isAdd = userRepository.RegisterUser(userDetails);
                        if (isAdd)
                        {
                            try
                            {
                                ActiveStatus status = new ActiveStatus
                                {
                                    UserId = userDetails.UserId,
                                    IsActive = true,
                                    LastSeen = DateTime.Now,
                                };

                                userRepository.AddActiveStatus(status);
                            }

                            catch (Exception ex)
                            { Console.WriteLine(ex); }

                            Console.WriteLine("Welocome {0} !!", userDetails.UserName);
                            menu.PostLoggedMenu(userDetails.UserId);

                        }

                    }
                    else
                    {
                        Console.WriteLine("Password Required");
                        goto password;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid email!");
                goto email;
            }
        }
        public void LogIn()
        {
        Start:
            Console.WriteLine("Login");
            Console.WriteLine("Enter Your username: ");
            string username = Console.ReadLine();
            if (String.IsNullOrEmpty(username))
            {
                Console.WriteLine("Enter a valid Username");
                goto Start;
            }
            else
            {
                try
                {
                    int userID = context.TWUser.FirstOrDefault(x => x.UserName.Equals(username)).UserId;
                    bool isActive = context.TWActiveStatus.FirstOrDefault(x => x.UserId == userID).IsActive;

                    if (isActive)
                    {
                        Console.WriteLine("You are already logged in !!! \n");
                        string uname = context.TWUser.FirstOrDefault(x => x.UserName.Equals(username)).UserName;
                        //logged.LogIn(userID);
                        menu.PostLoggedMenu(userID);
                    }
                    else
                    {
                        Console.WriteLine("Enter Password: ");
                        string password = Console.ReadLine();
                        var user = userRepository.GetUser(username);
                        if (user == null)
                        {
                            Console.WriteLine($"No user found with username {username}. Please register your account!");
                            Register();
                        }
                        else if (user.Password.Equals(password) && user.UserName.Equals(username))
                        {
                            Console.WriteLine("You have successfully logged in !!!");
                            logged.LogIn(user.UserId);
                            menu.PostLoggedMenu(user.UserId);
                        }
                        else if (username != user.UserName || password != user.Password)
                        {
                            Console.WriteLine("Your username or password is incorect, try again !!!");
                            goto Start;
                        }
                        else
                        {
                            Console.WriteLine("Try again !!!");
                            goto Start;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"No user exixts with {username}! \n");
                    exp:  Console.WriteLine("Kindly press Y to register! \n");
                    Console.WriteLine("Kindly press L/l to Login again. \n");
                    Console.WriteLine("Kindly press E/e to Exit \n");
                    string option = Console.ReadLine();
                    if (option.Equals("Y"))
                    {
                        Register();
                    }
                    else if(option.Equals("L") || option.Equals("l"))
                    {
                        LogIn();
                    }
                    else if (option.Equals("E") || option.Equals("e"))
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input. ");
                        goto exp;
                    }

                }
            }


        }

        public void ForgetPassword()
        {
            PreLogIn user = new PreLogIn();
            UserRepository userRepository = new UserRepository();
            Console.WriteLine("Forgot Password");
            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();
            var userDetails = userRepository.GetUser(userName: null, Email: email);
            if (userDetails != null)
            {
                userRepository.UpdateActiveStatusLoggingOut(userDetails.UserId);
                Console.WriteLine("Hi " + userDetails.UserName.ToString() + " The Email is already registered.");
                Console.WriteLine("Please proceed to reset the password");
                Console.WriteLine("Enter a new password: ");
                string password = Console.ReadLine();
            confirmation: Console.WriteLine("Confirm the Password: ");
                string cnfPassword = Console.ReadLine();
                if (cnfPassword != password)
                {
                    Console.WriteLine("Password not matching");
                    goto confirmation;
                }
                else
                {
                    int ID = userDetails.UserId;

                    if (userRepository.UpdatePassword(ID, password))
                    {
                        Console.WriteLine("Password has reset successfully!");
                    log: Console.WriteLine("Press M/m to login again");
                        Console.WriteLine("E/e for Exit");
                        string option = Console.ReadLine();
                        if (option.Equals("M") || option.Equals("m"))
                        {
                            user.LogIn();
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
                Console.WriteLine("This Email is not present in directory, Please REGISTER!!");
                user.Register();
            }

        }
    }
}

