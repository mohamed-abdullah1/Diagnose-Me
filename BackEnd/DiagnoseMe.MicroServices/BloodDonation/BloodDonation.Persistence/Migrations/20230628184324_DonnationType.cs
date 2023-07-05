using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DonnationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonnerId",
                table: "DonationRequests",
                newName: "Type");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 18, 43, 23, 837, DateTimeKind.Utc).AddTicks(7855),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 28, 15, 15, 56, 609, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "DonationRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 18, 43, 23, 818, DateTimeKind.Utc).AddTicks(8003),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 28, 15, 15, 56, 585, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 18, 43, 23, 838, DateTimeKind.Utc).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 18, 43, 23, 838, DateTimeKind.Utc).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 18, 43, 23, 838, DateTimeKind.Utc).AddTicks(568));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DonationRequests",
                newName: "DonnerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 15, 15, 56, 609, DateTimeKind.Utc).AddTicks(3628),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 28, 18, 43, 23, 837, DateTimeKind.Utc).AddTicks(7855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "DonationRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 28, 15, 15, 56, 585, DateTimeKind.Utc).AddTicks(5785),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 28, 18, 43, 23, 818, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 15, 15, 56, 609, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 15, 15, 56, 609, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 28, 15, 15, 56, 609, DateTimeKind.Utc).AddTicks(6193));
        }
    }
}
