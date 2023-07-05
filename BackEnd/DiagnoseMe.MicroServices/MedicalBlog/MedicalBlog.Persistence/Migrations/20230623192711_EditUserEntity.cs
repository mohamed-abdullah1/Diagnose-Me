using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 95, DateTimeKind.Utc).AddTicks(4975),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 342, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 93, DateTimeKind.Utc).AddTicks(2790),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 341, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 57, DateTimeKind.Utc).AddTicks(7620),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 329, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 933, DateTimeKind.Utc).AddTicks(190),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 301, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "PostImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 997, DateTimeKind.Utc).AddTicks(7143),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 310, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 878, DateTimeKind.Utc).AddTicks(512),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 289, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 852, DateTimeKind.Utc).AddTicks(2491),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 275, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                columns: new[] { "CreatedOn", "IsDoctor", "Rating", "Specialization" },
                values: new object[] { new DateTime(2023, 6, 23, 19, 27, 11, 158, DateTimeKind.Utc).AddTicks(4086), false, 0f, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "CreatedOn", "IsDoctor", "Rating", "Specialization" },
                values: new object[] { new DateTime(2023, 6, 23, 19, 27, 11, 158, DateTimeKind.Utc).AddTicks(4053), false, 0f, "Dental" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                columns: new[] { "CreatedOn", "IsDoctor", "Rating", "Specialization" },
                values: new object[] { new DateTime(2023, 6, 23, 19, 27, 11, 158, DateTimeKind.Utc).AddTicks(3875), false, 0f, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 342, DateTimeKind.Utc).AddTicks(8478),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 95, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 341, DateTimeKind.Utc).AddTicks(5160),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 93, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 329, DateTimeKind.Utc).AddTicks(2038),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 11, 57, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 301, DateTimeKind.Utc).AddTicks(4763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 933, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "PostImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 310, DateTimeKind.Utc).AddTicks(6219),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 997, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 289, DateTimeKind.Utc).AddTicks(7422),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 878, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 1, 26, 275, DateTimeKind.Utc).AddTicks(3935),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 27, 10, 852, DateTimeKind.Utc).AddTicks(2491));

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
    }
}
