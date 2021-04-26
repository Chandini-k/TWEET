// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or Sets UserId.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Gender.
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets DOB.
        /// </summary>
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or Sets EmailId.
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or Sets Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets ImageName.
        /// </summary>
        public string ImageName { get; set; }
    }
}
