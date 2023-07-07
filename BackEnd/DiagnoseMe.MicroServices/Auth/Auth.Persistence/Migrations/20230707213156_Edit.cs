using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUserNameChangeDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(8660),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEmailChangeDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7974),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastConfirmationSentDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7128),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                columns: new[] { "ConcurrencyStamp", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3387c24-dcec-4dbb-860c-3e3de9072cc6", new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7128), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7974), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(8660), "AQAAAAIAAYagAAAAEIA/1uJfuL9YtWOPsMrw8WwPs82MvgDsF1YJSrLzPpofpAz/TamY+iAfAS44ZMxzoQ==", "1eaf3b14-9f8b-48e5-8658-5516244fc054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "ConcurrencyStamp", "IsDoctor", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "989151d6-fb9c-4653-9362-334ab6fdb30a", true, new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7128), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7974), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(8660), "AQAAAAIAAYagAAAAEF9X7QHBbDMn23pA26kLcGDtqJkAjCo7ezjTW289ABgYas61xaWogdMVxjcBO9BhpA==", "5b8a0f13-fb3b-4a3b-9ba7-873c3af7780a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                columns: new[] { "ConcurrencyStamp", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d46b60-9789-40f2-a45f-4e42a2836ecc", new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7128), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7974), new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(8660), "AQAAAAIAAYagAAAAECp4wz9fJ+uoq0UTGdQnhvvVpvyW9GllVW1Fmlcxi9BuFUUrnoFoh0vwfsLEnh4/sA==", "59105ff8-f2f9-4a12-8958-cd01e85cd1a2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUserNameChangeDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(7969),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEmailChangeDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(6657),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastConfirmationSentDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(4729),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 7, 7, 21, 31, 55, 398, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00edafe3-b047-5980-d0fa-da10f400c1e5",
                columns: new[] { "ConcurrencyStamp", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f71db386-d30e-451e-8435-b1516b42d9a3", new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(4729), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(6657), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(7969), "AQAAAAIAAYagAAAAEF4DU/NcymnFR41/25Rvj8cm4k5XbBINcEIwUVji2Sf9+6euOKwc13S4LalayCusSg==", "cb3b5db6-f1a0-479f-85b5-4ff188108895" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                columns: new[] { "ConcurrencyStamp", "IsDoctor", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6eb8616-664d-496e-9323-b74d8e538ccb", false, new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(4729), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(6657), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(7969), "AQAAAAIAAYagAAAAEKLNVePb72f6YpgBg64T+8CBpTVZz69XxtiPpYsC4qB3OMkujJBXLkcTioGPhim4Ug==", "d9df3508-ebd7-4ab1-ae25-ad4ecef4d2a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "972a1201-a9dc-2127-0827-560cb7d76af8",
                columns: new[] { "ConcurrencyStamp", "LastConfirmationSentDate", "LastEmailChangeDate", "LastUserNameChangeDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5573a79f-9a5e-46e3-87bb-654af78fb6a7", new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(4729), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(6657), new DateTime(2023, 4, 25, 23, 18, 2, 608, DateTimeKind.Utc).AddTicks(7969), "AQAAAAIAAYagAAAAEAtrKJxbQyk4aOplqmDb//Ae18k44bIm7rUw4aDq5EelCMuERb1tNZHBSabcmsLuKQ==", "0c5a9ee8-c77e-45dd-b40c-dd78f1c981e1" });
        }
    }
}
