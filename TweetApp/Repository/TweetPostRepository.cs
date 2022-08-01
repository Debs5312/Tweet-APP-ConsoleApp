using System;
using System.Collections.Generic;
using System.Linq;
using TweetApp.DBContext;
using TweetApp.Model;
using TweetApp.Model.DTO;

namespace TweetApp.Repository
{
    public class TweetPostRepository
    {
        public List<TweetPostDTO> GetMyTweet(int userID)
        {
            var myTweets = new List<TweetPostDTO>();
            try
            {
                using (var _tweetContext = new TweetContext())
                {
                    var allTweet = _tweetContext.TWTweetpost.Where(x => x.PostedBy == userID).ToList();

                    string userName = _tweetContext.TWUser.FirstOrDefault(x => x.UserId == userID).UserName;



                    if (allTweet.Count == 0)
                    {

                        return null;
                    }
                    else
                    {
                        foreach (var tweet in allTweet)
                        {
                            myTweets.Add(new TweetPostDTO()
                            {
                                Caption = tweet.Caption,
                                Username = userName,
                                PostBody = tweet.PostBody,
                                PostedOn = tweet.PostedOn,
                            });
                        }
                        return myTweets;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public List<TweetPostDTO> GetAllTweet()
        {
            var tweets = new List<TweetPostDTO>();
            try
            {
                using (var _tweetContext = new TweetContext())
                {
                    var allTweet = _tweetContext.TWTweetpost.ToList();
                    if (allTweet.Count == 0)
                    {

                        return null;
                    }
                    else
                    {
                        foreach (var tweet in allTweet)
                        {
                            string userName = _tweetContext.TWUser.FirstOrDefault(x => x.UserId == tweet.PostedBy).UserName;
                            tweets.Add(new TweetPostDTO()
                            {
                                Caption = tweet.Caption,
                                Username = userName,
                                PostBody = tweet.PostBody,
                                PostedOn = tweet.PostedOn,
                            });
                        }
                        return tweets;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public bool PostTweet(TweetPost post)
        {
            if (post == null)
            {
                return false;
            }
            using (var _tweetContext = new TweetContext())
            {
                try
                {
                    _tweetContext.TWTweetpost.Add(post);
                    int save = _tweetContext.SaveChanges();
                    if (save > 0)
                    {
                        Console.WriteLine("Posted");
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("Not Posted");
                    return false;
                }
            }
        }

        public List<UserDetails> GetAllUsers()
        {
            var users = new List<UserDetails>();
            try
            {
                using (var _tweetContext = new TweetContext())
                {
                    var allUsers = _tweetContext.TWUser.ToList();
                    if (allUsers.Count == 0)
                    {
                        Console.WriteLine("No Users are there till now!!");
                        return null;
                    }
                    else
                    {
                        foreach (var user in allUsers)
                        {
                            users.Add(new UserDetails()
                            {
                                UserId = user.UserId,
                                UserName = user.UserName,
                                Email = user.Email,
                                Gender = user.Gender
                            });
                        }
                        return users;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
