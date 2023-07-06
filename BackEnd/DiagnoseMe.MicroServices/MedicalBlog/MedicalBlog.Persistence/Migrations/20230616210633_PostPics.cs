using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PostPics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 817, DateTimeKind.Utc).AddTicks(7400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 174, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 816, DateTimeKind.Utc).AddTicks(4991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 172, DateTimeKind.Utc).AddTicks(1063));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 804, DateTimeKind.Utc).AddTicks(2009),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 156, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 777, DateTimeKind.Utc).AddTicks(9862),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 95, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 768, DateTimeKind.Utc).AddTicks(2980),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 83, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 750, DateTimeKind.Utc).AddTicks(6537),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 49, DateTimeKind.Utc).AddTicks(696));

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 785, DateTimeKind.Utc).AddTicks(6272)),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserSavedPost",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavedPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSavedPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavedPost_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 16, 21, 6, 32, 886, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 16, 21, 6, 32, 886, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 16, 21, 6, 32, 886, DateTimeKind.Utc).AddTicks(5676));

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedPost_PostId",
                table: "UserSavedPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedPost_UserId",
                table: "UserSavedPost",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "UserSavedPost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 174, DateTimeKind.Utc).AddTicks(3263),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 817, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 172, DateTimeKind.Utc).AddTicks(1063),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 816, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 156, DateTimeKind.Utc).AddTicks(6570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 804, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 95, DateTimeKind.Utc).AddTicks(5565),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 777, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 83, DateTimeKind.Utc).AddTicks(8367),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 768, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 27, 23, 5, 43, 49, DateTimeKind.Utc).AddTicks(696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 750, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 27, 23, 5, 43, 196, DateTimeKind.Utc).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 27, 23, 5, 43, 196, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 27, 23, 5, 43, 196, DateTimeKind.Utc).AddTicks(9043));
        }
    }
}
