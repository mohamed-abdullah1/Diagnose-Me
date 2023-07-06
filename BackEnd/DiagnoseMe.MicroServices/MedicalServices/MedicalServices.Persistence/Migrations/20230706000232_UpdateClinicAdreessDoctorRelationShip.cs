using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClinicAdreessDoctorRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorClinicAdresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 569, DateTimeKind.Utc).AddTicks(9421),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 563, DateTimeKind.Utc).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 80, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 537, DateTimeKind.Utc).AddTicks(2220),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 57, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 514, DateTimeKind.Utc).AddTicks(5084),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 502, DateTimeKind.Utc).AddTicks(6454),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 12, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 497, DateTimeKind.Utc).AddTicks(3993),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 6, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 495, DateTimeKind.Utc).AddTicks(9755),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 994, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 477, DateTimeKind.Utc).AddTicks(1874),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 972, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 493, DateTimeKind.Utc).AddTicks(1927),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 991, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 469, DateTimeKind.Utc).AddTicks(6613),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 966, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 497, DateTimeKind.Utc).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 514, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 537, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 569, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 569, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 7, 6, 0, 2, 31, 569, DateTimeKind.Utc).AddTicks(9421));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 87, DateTimeKind.Utc).AddTicks(6614),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 569, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 80, DateTimeKind.Utc).AddTicks(9400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 563, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 57, DateTimeKind.Utc).AddTicks(2300),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 537, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 514, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 12, DateTimeKind.Utc).AddTicks(7071),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 502, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 3, 6, DateTimeKind.Utc).AddTicks(4850),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 497, DateTimeKind.Utc).AddTicks(3993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 994, DateTimeKind.Utc).AddTicks(1175),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 495, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 972, DateTimeKind.Utc).AddTicks(763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 477, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CheckFiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 991, DateTimeKind.Utc).AddTicks(5016),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 493, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 1, 9, 2, 966, DateTimeKind.Utc).AddTicks(5286),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 6, 0, 2, 31, 469, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.CreateTable(
                name: "DoctorClinicAdresses",
                columns: table => new
                {
                    DoctorId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClinicAddressId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinicAdresses", x => new { x.DoctorId, x.ClinicAddressId });
                    table.ForeignKey(
                        name: "FK_DoctorClinicAdresses_ClinicAddresses_ClinicAddressId",
                        column: x => x.ClinicAddressId,
                        principalTable: "ClinicAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorClinicAdresses_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                column: "CreatedOn",
                value: new DateTime(2023, 7, 4, 1, 9, 3, 31, DateTimeKind.Utc).AddTicks(7540));

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

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicAdresses_ClinicAddressId",
                table: "DoctorClinicAdresses",
                column: "ClinicAddressId");
        }
    }
}
