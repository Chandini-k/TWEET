// <copyright file="Tweet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Models
{
    /// <summary>
    /// Tweet.
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Tweets.
        /// </summary>
        public string Tweets { get; set; }

        /// <summary>
        /// Gets or Sets Likes.
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// Gets or Sets Comments.
        /// </summary>
        public string Comments { get; set; }
    }
}
