using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeProfilePicRequire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(982),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "DonationRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 20, 44, 26, 210, DateTimeKind.Utc).AddTicks(965),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 856, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2292));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(366),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "DonationRequests",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 17, 47, 30, 856, DateTimeKind.Utc).AddTicks(3285),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 19, 20, 44, 26, 210, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                column: "CreatedOn",
                value: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                column: "CreatedOn",
                value: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                column: "CreatedOn",
                value: new DateTime(2023, 3, 11, 17, 47, 30, 858, DateTimeKind.Utc).AddTicks(2111));
        }
    }
}
