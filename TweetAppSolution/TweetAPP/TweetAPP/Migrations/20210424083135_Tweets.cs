// <copyright file="20210424083135_Tweets.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Tweets.
    /// </summary>
    public partial class Tweets : Migration
    {
        /// <summary>
        /// Up.
        /// </summary>
        /// <param name="migrationBuilder">migrationBuilder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.AlterColumn<int>(
                    name: "Likes",
                    table: "Tweets",
                    type: "int",
                    nullable: false,
                    defaultValue: 0,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(max)",
                    oldNullable: true);
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
                migrationBuilder.AlterColumn<string>(
                    name: "Likes",
                    table: "Tweets",
                    type: "nvarchar(max)",
                    nullable: true,
                    oldClrType: typeof(int),
                    oldType: "int");
            }
        }
    }
}
