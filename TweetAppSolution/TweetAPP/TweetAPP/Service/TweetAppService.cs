﻿// <copyright file="TweetAppService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using TweetAPP.Models;
    using TweetAPP.Repositories;

    /// <summary>
    /// TweetAppService.
    /// </summary>
    public class TweetAppService : ITweetAppService
    {
        private readonly ITweetRepository tweetRepository;
        private ILogger<TweetAppService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TweetAppService"/> class.
        /// TweetAppService.
        /// </summary>
        /// <param name="tweetRepository">tweetRepository.</param>
        /// <param name="logger">logger.</param>
        public TweetAppService(ITweetRepository tweetRepository, ILogger<TweetAppService> logger)
        {
            this.tweetRepository = tweetRepository;
            this.logger = logger;
        }

        /// <summary>
        /// Comments.
        /// </summary>
        /// <param name="comment">comment.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        public async Task<bool> Comments(string comment, int userid)
        {
            try
            {
                var result = await this.tweetRepository.Comments(comment, userid);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while posting comment");
                throw;
            }
        }

        /// <summary>
        /// ForgotPassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        public async Task<string> ForgotPassword(string emailId, string password)
        {
            try
            {
                string message = string.Empty;
                if (password != null)
                {
                    password = this.EncryptPassword(password);
                }

                var result = await this.tweetRepository.ForgotPassword(emailId, password);
                if (result)
                {
                    message = "Changed Password";
                }
                else
                {
                    message = "Failed";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while reseting password");
                throw;
            }
        }

        /// <summary>
        /// GetAllTweets.
        /// </summary>
        /// <returns>response.</returns>
        public async Task<List<UserTweets>> GetAllTweets()
        {
            try
            {
                var result = await this.tweetRepository.GetAllTweets();
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving all tweets");
                throw;
            }
        }

        /// <summary>
        /// GetAllUsers.
        /// </summary>
        /// <returns>response.</returns>
        public async Task<IList<RegisteredUser>> GetAllUsers()
        {
            try
            {
                var result = await this.tweetRepository.GetAllUsers();
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving all registered users");
                throw;
            }
        }

        /// <summary>
        /// GetTweetsByUser.
        /// </summary>
        /// <param name="username">username.</param>
        /// <returns>response.</returns>
        public async Task<List<UserTweets>> GetTweetsByUser(string username)
        {
            try
            {
                var result = await this.tweetRepository.GetTweetsByUser(username);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while retrieving tweets by user");
                throw;
            }
        }

        /// <summary>
        /// Likes.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        public async Task<bool> Likes(int count, int userid)
        {
            try
            {
                var result = await this.tweetRepository.Likes(count, userid);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while reseting password");
                throw;
            }
        }

        /// <summary>
        /// PostTweet.
        /// </summary>
        /// <param name="tweet">tweet.</param>
        /// <returns>response.</returns>
        public async Task<string> PostTweet(Tweet tweet)
        {
            try
            {
                string message = string.Empty;
                var result = await this.tweetRepository.PostTweet(tweet);
                if (result > 0)
                {
                    message = "Posted";
                }
                else
                {
                    message = "Error occured";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while posting tweets");
                throw;
            }
        }

        /// <summary>
        /// UpdatePassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="oldpassword">oldpassword.</param>
        /// <param name="newPassword">newPassword.</param>
        /// <returns>response.</returns>
        public async Task<string> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                string message = string.Empty;
                if (newPassword != null && oldpassword != null)
                {
                    newPassword = this.EncryptPassword(newPassword);
                    oldpassword = this.EncryptPassword(oldpassword);
                }

                var result = await this.tweetRepository.UpdatePassword(emailId, oldpassword, newPassword);
                if (result)
                {
                    message = "Updated Successfully";
                }
                else
                {
                    message = "Update Failed";
                }

                return message;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while updating password");
                throw;
            }
        }

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        public async Task<User> UserLogin(string emailId, string password)
        {
            try
            {
                if (password != null)
                {
                    password = this.EncryptPassword(password);
                }

                var result = await this.tweetRepository.Login(emailId, password);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while logging in");
                throw;
            }
        }

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="users">users.</param>
        /// <returns>response.</returns>
        public async Task<string> UserRegister(User users)
        {
            try
            {
                if (users != null)
                {
                    string message = string.Empty;
                    var validate = await this.tweetRepository.ValidateEmailId(users.EmailId);
                    var uservalidate = await this.tweetRepository.ValidateName(users.FirstName);
                    if (validate == null && uservalidate == null)
                    {
                        users.Password = this.EncryptPassword(users.Password);
                        var result = await this.tweetRepository.Register(users);
                        if (result > 0)
                        {
                            message = "Successfully registerd";
                        }
                        else
                        {
                            message = "Registration failed";
                        }
                    }
                    else
                    {
                        if (validate != null)
                        {
                            message = "EmailId is already used";
                        }
                        else
                        {
                            message = "Username is already taken";
                        }
                    }

                    return message;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering");
                throw;
            }
        }

        private string EncryptPassword(string password)
        {
            string message = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            message = Convert.ToBase64String(encode);
            return message;
        }
    }
}