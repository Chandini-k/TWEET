// <copyright file="20210426034242_Tweetss.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Tweetss.
    /// </summary>
    public partial class Tweetss : Migration
    {
        /// <summary>
        /// Up.
        /// </summary>
        /// <param name="migrationBuilder">migrationBuilder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.AddColumn<string>(
                    name: "ImageName",
                    table: "User",
                    type: "nvarchar(max)",
                    nullable: true);
            }
        }

        /// <summary>
        /// Down.
        /// </summary>
        /// <param name="migrationBuilder">migrationBuilder.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.DropColumn(
                    name: "ImageName",
                    table: "User");
            }
        }
    }
}
