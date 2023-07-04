using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingDoctorPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 80, DateTimeKind.Utc).AddTicks(9400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 612, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 57, DateTimeKind.Utc).AddTicks(2300),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 587, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 548, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.AddColumn<int>(
                name: "PricePerSession",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 12, DateTimeKind.Utc).AddTicks(7071),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 515, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 6, DateTimeKind.Utc).AddTicks(4850),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 510, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 994, DateTimeKind.Utc).AddTicks(1175),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 504, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 972, DateTimeKind.Utc).AddTicks(763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 485, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 991, DateTimeKind.Utc).AddTicks(5016),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 499, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 966, DateTimeKind.Utc).AddTicks(5286),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 480, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 6, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "CreatedOn", "PricePerSession" },
                values: new object[] { new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540), 0 });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 57, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerSession",
                table: "Doctors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 617, DateTimeKind.Utc).AddTicks(7261),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 612, DateTimeKind.Utc).AddTicks(460),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 80, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 587, DateTimeKind.Utc).AddTicks(4842),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 57, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 548, DateTimeKind.Utc).AddTicks(6116),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 515, DateTimeKind.Utc).AddTicks(40),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 12, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 510, DateTimeKind.Utc).AddTicks(1803),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 6, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 504, DateTimeKind.Utc).AddTicks(662),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 994, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 485, DateTimeKind.Utc).AddTicks(6610),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 972, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 499, DateTimeKind.Utc).AddTicks(4368),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 991, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 9, 29, 5, 480, DateTimeKind.Utc).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 966, DateTimeKind.Utc).AddTicks(5286));

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
        }
    }
}
