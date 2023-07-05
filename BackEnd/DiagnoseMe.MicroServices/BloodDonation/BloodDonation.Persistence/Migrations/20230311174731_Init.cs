﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDonation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfilePictureUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BloodType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastDonationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(366)),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DonationRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequesterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BloodType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DonnerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 856, DateTimeKind.Utc).AddTicks(3285)),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationRequests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DonnerDonationRequests",
                columns: table => new
                {
                    DonnerId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DonationRequestId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonnerDonationRequests", x => new { x.DonnerId, x.DonationRequestId });
                    table.ForeignKey(
                        name: "FK_DonnerDonationRequests_DonationRequests_DonationRequestId",
                        column: x => x.DonationRequestId,
                        principalTable: "DonationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonnerDonationRequests_Users_DonnerId",
                        column: x => x.DonnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BloodType", "ConcurrencyStamp", "CreatedOn", "FullName", "LastDonationDate", "Name", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { "00edafe3-b047-5980-d0fa-da10f400c1e5", "A+", null, new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2173), "Admin", null, "Admin", "" },
                    { "657cb6cb-abf2-00d1-5d46-939a7b3aff5f", "A+", null, new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2154), "Doctor", null, "Doctor", "" },
                    { "972a1201-a9dc-2127-0827-560cb7d76af8", "A+", null, new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2111), "Patient", null, "Patient", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationRequests_RequesterId",
                table: "DonationRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DonnerDonationRequests_DonationRequestId",
                table: "DonnerDonationRequests",
                column: "DonationRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonnerDonationRequests");

            migrationBuilder.DropTable(
                name: "DonationRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
