using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RestructureSomePropInDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 612, DateTimeKind.Utc).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 375, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 587, DateTimeKind.Utc).AddTicks(4842),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 241, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Doctors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Doctors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 548, DateTimeKind.Utc).AddTicks(6116),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 140, DateTimeKind.Utc).AddTicks(6221));

            migrationBuilder.AlterColumn<string>(
                name: "ClinicId",
                table: "Doctors",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Doctors",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 515, DateTimeKind.Utc).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 86, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 510, DateTimeKind.Utc).AddTicks(1803),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 69, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 504, DateTimeKind.Utc).AddTicks(662),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 43, DateTimeKind.Utc).AddTicks(7242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 485, DateTimeKind.Utc).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 980, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 499, DateTimeKind.Utc).AddTicks(4368),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 34, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 480, DateTimeKind.Utc).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 958, DateTimeKind.Utc).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 510, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 548, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 587, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 375, DateTimeKind.Utc).AddTicks(7436),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 612, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 241, DateTimeKind.Utc).AddTicks(2836),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 587, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Title",
                keyValue: null,
                column: "Title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "License",
                keyValue: null,
                column: "License",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "License",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
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
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 548, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "ClinicId",
                keyValue: null,
                column: "ClinicId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicId",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Bio",
                keyValue: null,
                column: "Bio",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Doctors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 86, DateTimeKind.Utc).AddTicks(1823),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 515, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 69, DateTimeKind.Utc).AddTicks(7333),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 510, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 43, DateTimeKind.Utc).AddTicks(7242),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 504, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 980, DateTimeKind.Utc).AddTicks(580),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 485, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 44, 34, DateTimeKind.Utc).AddTicks(304),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 499, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 16, 55, 43, 958, DateTimeKind.Utc).AddTicks(8519),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 480, DateTimeKind.Utc).AddTicks(8340));

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
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 140, DateTimeKind.Utc).AddTicks(6221));

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
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 16, 55, 44, 395, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
