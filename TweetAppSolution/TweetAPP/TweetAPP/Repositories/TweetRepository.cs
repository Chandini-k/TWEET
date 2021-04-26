// <copyright file="TweetRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TweetAPP.Models;

    /// <summary>
    /// TweetRepository.
    /// </summary>
    public class TweetRepository : ITweetRepository
    {
        private readonly TweetDBContext dbcontext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TweetRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public TweetRepository(TweetDBContext context)
        {
            this.dbcontext = context;
        }

        /// <summary>
        /// Comments.
        /// </summary>
        /// <param name="comment">.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        public async Task<bool> Comments(string comment, int userid)
        {
            var result = await this.dbcontext.Tweets.Where(s => s.UserId == userid).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Comments = comment;
                this.dbcontext.Update(result);
                var response = this.dbcontext.SaveChanges();
                if (response > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// ForgotPassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        public async Task<bool> ForgotPassword(string emailId, string password)
        {
            var result = await this.dbcontext.User.Where(s => s.EmailId == emailId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Password = password;
                this.dbcontext.Update(result);
                var response = this.dbcontext.SaveChanges();
                if (response > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// GetAllTweets.
        /// </summary>
        /// <returns>response.</returns>
        public async Task<List<UserTweets>> GetAllTweets()
        {
            var result = await (from tweet in this.dbcontext.Tweets join user in this.dbcontext.User on tweet.UserId equals user.UserId select new UserTweets { UserName = user.FirstName, Tweets = tweet.Tweets }).ToListAsync();
            return result;
        }

        /// <summary>
        /// GetAllUsers.
        /// </summary>
        /// <returns>response.</returns>
        public async Task<IList<RegisteredUser>> GetAllUsers()
        {
            var result = await this.dbcontext.User.Select(p => new RegisteredUser
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
            }).ToListAsync();
            return result;
        }

        /// <summary>
        /// GetTweetsByUser.
        /// </summary>
        /// <param name="username">username.</param>
        /// <returns>response.</returns>
        public async Task<List<UserTweets>> GetTweetsByUser(string username)
        {
            var users = await this.dbcontext.User.FirstOrDefaultAsync(e => e.FirstName == username);
            var result = await (from tweet in this.dbcontext.Tweets join user in this.dbcontext.User on tweet.UserId equals user.UserId where tweet.UserId == users.UserId select new UserTweets { UserName = user.FirstName, Tweets = tweet.Tweets }).ToListAsync();
            return result;
        }

        /// <summary>
        /// Likes.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        public async Task<bool> Likes(int count, int userid)
        {
            var result = await this.dbcontext.Tweets.Where(s => s.UserId == userid).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Likes = count;
                this.dbcontext.Update(result);
                var response = this.dbcontext.SaveChanges();
                if (response > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        public async Task<User> Login(string emailId, string password)
        {
            User user = await this.dbcontext.User.FirstOrDefaultAsync(e => e.EmailId == emailId && e.Password == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// PostTweet.
        /// </summary>
        /// <param name="tweet">tweet.</param>
        /// <returns>response.</returns>
        public async Task<int> PostTweet(Tweet tweet)
        {
            this.dbcontext.Tweets.Add(tweet);
            var result = await this.dbcontext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="users">users.</param>
        /// <returns>response.</returns>
        public async Task<int> Register(User users)
        {
            this.dbcontext.User.Add(users);
            var result = await this.dbcontext.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// UpdatePassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="oldpassword">oldpassword.</param>
        /// <param name="newPassword">newPassword.</param>
        /// <returns>response.</returns>
        public async Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            var update = await this.dbcontext.User.Where(x => x.EmailId == emailId && x.Password == oldpassword).FirstOrDefaultAsync();
            if (update != null)
            {
                update.Password = newPassword;
                this.dbcontext.User.Update(update);
                var result = await this.dbcontext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// ValidateEmailId.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <returns>response.</returns>
        public async Task<User> ValidateEmailId(string emailId)
        {
            var user = await this.dbcontext.User.FirstOrDefaultAsync(e => e.EmailId == emailId);
            return user;
        }

        /// <summary>
        /// ValidateName.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>response.</returns>
        public async Task<User> ValidateName(string firstName)
        {
            var user = await this.dbcontext.User.FirstOrDefaultAsync(e => e.FirstName == firstName);
            return user;
        }
    }
}
