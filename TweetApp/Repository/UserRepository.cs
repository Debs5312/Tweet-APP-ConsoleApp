using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TweetApp.DBContext;
using TweetApp.Model;

namespace TweetApp.Repository
{


    internal class UserRepository
    {
        public bool UpdateActiveStatusLoggingIn(int id)
        {
            using (var _tweetContext = new TweetContext())
            {
                var user = _tweetContext.TWActiveStatus.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    user.IsActive = true;
                    user.LastSeen = DateTime.Now;
                    _tweetContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string GetuserName(int id)
        {
            using (var _tweetContext = new TweetContext())
            {
                var user = _tweetContext.TWUser.FirstOrDefault(x => x.UserId == id).UserName;
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
        public bool UpdateActiveStatusLoggingOut(int id)
        {
            using (var _tweetContext = new TweetContext())
            {
                var user = _tweetContext.TWActiveStatus.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    user.IsActive = false;
                    user.LastSeen = DateTime.Now;
                    _tweetContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AddActiveStatus(ActiveStatus status)
        {
            using (var _tweetContext = new TweetContext())
            {
                _tweetContext.TWActiveStatus.Add(status);
                if (_tweetContext.SaveChanges() > 0)
                    return true;
                return false;
            }

        }

        public IEnumerable<UserDetails> GetAllUsers()
        {
            using (var _tweetContext = new TweetContext())
                return _tweetContext.TWUser.ToList();
        }

        public UserDetails GetUser([Optional] string userName, [Optional] string Email)
        {
            using (var _tweetContext = new TweetContext())
            {
                if (userName != null)
                {
                    return _tweetContext.TWUser.FirstOrDefault(x => x.UserName == userName);
                }
                else if (userName == null && Email != null)
                {
                    return _tweetContext.TWUser.FirstOrDefault(x => x.Email == Email);
                }
                else
                    return null;
            }
        }



        public bool RegisterUser(UserDetails userDetails)
        {
            if (userDetails == null)
            {
                return false;
            }
            try
            {
                using (var _tweetContext = new TweetContext())
                {
                    _tweetContext.TWUser.Add(userDetails);
                    if (_tweetContext.SaveChanges() > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdatePassword(int id, string pass)
        {
            using (var _tweetContext = new TweetContext())
            {
                var user = _tweetContext.TWUser.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    user.Password = pass;
                    _tweetContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

}

