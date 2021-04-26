// <copyright file="20210424081610_tweet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// tweet.
    /// </summary>
    public partial class tweet : Migration
    {
        /// <summary>
        /// Up.
        /// </summary>
        /// <param name="migrationBuilder">migrationBuilder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.DropForeignKey(
                name: "FK_Tweets_User_UserId",
                table: "Tweets");

                migrationBuilder.DropIndex(
                    name: "IX_Tweets_UserId",
                    table: "Tweets");

                migrationBuilder.AddColumn<string>(
                    name: "Comments",
                    table: "Tweets",
                    type: "nvarchar(max)",
                    nullable: true);

                migrationBuilder.AddColumn<string>(
                    name: "Likes",
                    table: "Tweets",
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
                name: "Comments",
                table: "Tweets");

                migrationBuilder.DropColumn(
                    name: "Likes",
                    table: "Tweets");

                migrationBuilder.CreateIndex(
                    name: "IX_Tweets_UserId",
                    table: "Tweets",
                    column: "UserId");

                migrationBuilder.AddForeignKey(
                    name: "FK_Tweets_User_UserId",
                    table: "Tweets",
                    column: "UserId",
                    principalTable: "User",
                    principalColumn: "UserId",
                    onDelete: ReferentialAction.Cascade);
            }
        }
    }
}
