using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Addingclinicprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 241, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 375, DateTimeKind.Utc).AddTicks(7436),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 224, DateTimeKind.Utc).AddTicks(532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 241, DateTimeKind.Utc).AddTicks(2836),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 177, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 140, DateTimeKind.Utc).AddTicks(6221),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 157, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 86, DateTimeKind.Utc).AddTicks(1823),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 142, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 69, DateTimeKind.Utc).AddTicks(7333),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 137, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 43, DateTimeKind.Utc).AddTicks(7242),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 110, DateTimeKind.Utc).AddTicks(9469));

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "ClinicAddresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "ClinicAddresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 980, DateTimeKind.Utc).AddTicks(580),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 94, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 34, DateTimeKind.Utc).AddTicks(304),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 108, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 958, DateTimeKind.Utc).AddTicks(8519),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 89, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 69, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "CreatedOn", "YearsOfExperience" },
                values: new object[] { new DateTime(2023, 7, 1, 16, 55, 44, 140, DateTimeKind.Utc).AddTicks(6221), 0 });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 241, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "CreatedOn", "IsDoctor" },
                values: new object[] { new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ClinicAddresses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ClinicAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 241, DateTimeKind.Utc).AddTicks(6647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 224, DateTimeKind.Utc).AddTicks(532),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 375, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 177, DateTimeKind.Utc).AddTicks(9162),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 241, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Doctors",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Doctors",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 157, DateTimeKind.Utc).AddTicks(2290),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 140, DateTimeKind.Utc).AddTicks(6221));

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Doctors",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 142, DateTimeKind.Utc).AddTicks(4394),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 86, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 137, DateTimeKind.Utc).AddTicks(2194),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 69, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 110, DateTimeKind.Utc).AddTicks(9469),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 43, DateTimeKind.Utc).AddTicks(7242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 94, DateTimeKind.Utc).AddTicks(8494),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 980, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 108, DateTimeKind.Utc).AddTicks(3200),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 34, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 21, 8, 52, 89, DateTimeKind.Utc).AddTicks(5752),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 958, DateTimeKind.Utc).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 8, 52, 137, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 8, 52, 157, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 8, 52, 177, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 8, 52, 241, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "CreatedOn", "IsDoctor" },
                values: new object[] { new DateTime(2023, 6, 19, 21, 8, 52, 241, DateTimeKind.Utc).AddTicks(6647), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 21, 8, 52, 241, DateTimeKind.Utc).AddTicks(6647));
        }
    }
}
