// <copyright file="20210326105401_TweetAppDB.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TweetAPP.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// TweetAppDB.
    /// </summary>
    public partial class TweetAppDB : Migration
    {
        /// <summary>
        /// Up.
        /// </summary>
        /// <param name="migrationBuilder">migrationBuilder.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

                migrationBuilder.CreateTable(
                    name: "Tweets",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        UserId = table.Column<int>(type: "int", nullable: false),
                        Tweets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Tweets", x => x.Id);
                        table.ForeignKey(
                            name: "FK_Tweets_User_UserId",
                            column: x => x.UserId,
                            principalTable: "User",
                            principalColumn: "UserId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateIndex(
                    name: "IX_Tweets_UserId",
                    table: "Tweets",
                    column: "UserId");
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
                migrationBuilder.DropTable(
                    name: "Tweets");

                migrationBuilder.DropTable(
                    name: "User");
            }
        }
    }
}
