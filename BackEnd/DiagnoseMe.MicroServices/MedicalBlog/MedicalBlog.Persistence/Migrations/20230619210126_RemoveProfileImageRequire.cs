using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProfileImageRequire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 342, DateTimeKind.Utc).AddTicks(8478),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 817, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 341, DateTimeKind.Utc).AddTicks(5160),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 816, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 329, DateTimeKind.Utc).AddTicks(2038),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 804, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 301, DateTimeKind.Utc).AddTicks(4763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 777, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "PostImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 310, DateTimeKind.Utc).AddTicks(6219),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 785, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 289, DateTimeKind.Utc).AddTicks(7422),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 768, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 275, DateTimeKind.Utc).AddTicks(3935),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 750, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 1, 26, 398, DateTimeKind.Utc).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 1, 26, 398, DateTimeKind.Utc).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 1, 26, 398, DateTimeKind.Utc).AddTicks(6897));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 817, DateTimeKind.Utc).AddTicks(7400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 342, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 816, DateTimeKind.Utc).AddTicks(4991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 341, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 804, DateTimeKind.Utc).AddTicks(2009),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 329, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 777, DateTimeKind.Utc).AddTicks(9862),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 301, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "PostImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 785, DateTimeKind.Utc).AddTicks(6272),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 310, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 768, DateTimeKind.Utc).AddTicks(2980),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 289, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 16, 21, 6, 32, 750, DateTimeKind.Utc).AddTicks(6537),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 275, DateTimeKind.Utc).AddTicks(3935));

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
        }
    }
}
