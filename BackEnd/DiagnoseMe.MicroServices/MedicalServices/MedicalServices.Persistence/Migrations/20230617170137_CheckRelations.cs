using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CheckRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Checks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 560, DateTimeKind.Utc).AddTicks(6839),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 267, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 508, DateTimeKind.Utc).AddTicks(1292),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 258, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 319, DateTimeKind.Utc).AddTicks(5495),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 229, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 208, DateTimeKind.Utc).AddTicks(2002),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 177, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 124, DateTimeKind.Utc).AddTicks(9893),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 150, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 106, DateTimeKind.Utc).AddTicks(6864),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 142, DateTimeKind.Utc).AddTicks(4064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 59, DateTimeKind.Utc).AddTicks(3399),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 128, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 2, DateTimeKind.Utc).AddTicks(6475),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 127, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Checks",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Checks",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 17, 1, 33, 986, DateTimeKind.Utc).AddTicks(622),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 122, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.CreateTable(
                name: "CheckAllergies",
                columns: table => new
                {
                    CheckId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AllergyId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckAllergies", x => new { x.CheckId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_CheckAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckAllergies_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckDiseases",
                columns: table => new
                {
                    CheckId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiseaseId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckDiseases", x => new { x.CheckId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_CheckDiseases_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CheckId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileUrl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 50, DateTimeKind.Utc).AddTicks(6348)),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckFiles_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckMedication",
                columns: table => new
                {
                    CheckId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicationId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckMedication", x => new { x.MedicationId, x.CheckId });
                    table.ForeignKey(
                        name: "FK_CheckMedication_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckMedication_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckSurgery",
                columns: table => new
                {
                    CheckId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SurgeryId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckSurgery", x => new { x.SurgeryId, x.CheckId });
                    table.ForeignKey(
                        name: "FK_CheckSurgery_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckSurgery_Surgeries_SurgeryId",
                        column: x => x.SurgeryId,
                        principalTable: "Surgeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 106, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 208, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 319, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 560, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 560, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 17, 1, 34, 560, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.CreateIndex(
                name: "IX_Checks_DoctorId",
                table: "Checks",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_PatientId",
                table: "Checks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckAllergies_AllergyId",
                table: "CheckAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckDiseases_DiseaseId",
                table: "CheckDiseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckFiles_CheckId",
                table: "CheckFiles",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckMedication_CheckId",
                table: "CheckMedication",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckSurgery_CheckId",
                table: "CheckSurgery",
                column: "CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Doctors_DoctorId",
                table: "Checks",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_Patients_PatientId",
                table: "Checks",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Doctors_DoctorId",
                table: "Checks");

            migrationBuilder.DropForeignKey(
                name: "FK_Checks_Patients_PatientId",
                table: "Checks");

            migrationBuilder.DropTable(
                name: "CheckAllergies");

            migrationBuilder.DropTable(
                name: "CheckDiseases");

            migrationBuilder.DropTable(
                name: "CheckFiles");

            migrationBuilder.DropTable(
                name: "CheckMedication");

            migrationBuilder.DropTable(
                name: "CheckSurgery");

            migrationBuilder.DropIndex(
                name: "IX_Checks_DoctorId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_PatientId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Checks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 267, DateTimeKind.Utc).AddTicks(3972),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 560, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Surgeries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 258, DateTimeKind.Utc).AddTicks(8371),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 508, DateTimeKind.Utc).AddTicks(1292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 229, DateTimeKind.Utc).AddTicks(29),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 319, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 177, DateTimeKind.Utc).AddTicks(7331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 208, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Diseases",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 150, DateTimeKind.Utc).AddTicks(6241),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 124, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Clinics",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 142, DateTimeKind.Utc).AddTicks(4064),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 106, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ClinicAddresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 128, DateTimeKind.Utc).AddTicks(757),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 59, DateTimeKind.Utc).AddTicks(3399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Checks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 127, DateTimeKind.Utc).AddTicks(1570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 34, 2, DateTimeKind.Utc).AddTicks(6475));

            migrationBuilder.AddColumn<string>(
                name: "MedicalRecordId",
                table: "Checks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 18, 14, 56, 59, 122, DateTimeKind.Utc).AddTicks(8917),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 17, 17, 1, 33, 986, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 142, DateTimeKind.Utc).AddTicks(4064));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 177, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 229, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 267, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 267, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 4, 18, 14, 56, 59, 267, DateTimeKind.Utc).AddTicks(3972));
        }
    }
}
