// <copyright file="ITweetRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TweetAPP.Models;

    /// <summary>
    /// Interface ITweetRepository.
    /// </summary>
    public interface ITweetRepository
    {
        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="users">users.</param>
        /// <returns>response.</returns>
        Task<int> Register(User users);

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        Task<User> Login(string emailId, string password);

        /// <summary>
        /// GetAllTweets.
        /// </summary>
        /// <returns>response.</returns>
        Task<List<UserTweets>> GetAllTweets();

        /// <summary>
        /// GetTweetsByUser.
        /// </summary>
        /// <param name="username">username.</param>
        /// <returns>response.</returns>
        Task<List<UserTweets>> GetTweetsByUser(string username);

        /// <summary>
        /// GetAllUsers.
        /// </summary>
        /// <returns>response.</returns>
        Task<IList<RegisteredUser>> GetAllUsers();

        /// <summary>
        /// PostTweet.
        /// </summary>
        /// <param name="tweet">tweet.</param>
        /// <returns>response.</returns>
        Task<int> PostTweet(Tweet tweet);

        /// <summary>
        /// UpdatePassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="oldpassword">oldpassword.</param>
        /// <param name="newPassword">newPassword.</param>
        /// <returns>response.</returns>
        Task<bool> UpdatePassword(string emailId, string oldpassword, string newPassword);

        /// <summary>
        /// ForgotPassword.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <param name="password">password.</param>
        /// <returns>response.</returns>
        Task<bool> ForgotPassword(string emailId, string password);

        /// <summary>
        /// ValidateEmailId.
        /// </summary>
        /// <param name="emailId">emailId.</param>
        /// <returns>response.</returns>
        Task<User> ValidateEmailId(string emailId);

        /// <summary>
        /// ValidateName.
        /// </summary>
        /// <param name="firstName">firstName.</param>
        /// <returns>response.</returns>
        Task<User> ValidateName(string firstName);

        /// <summary>
        /// Likes.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        Task<bool> Likes(int count, int userid);

        /// <summary>
        /// Comments.
        /// </summary>
        /// <param name="comment">comment.</param>
        /// <param name="userid">userid.</param>
        /// <returns>response.</returns>
        Task<bool> Comments(string comment, int userid);
    }
}
