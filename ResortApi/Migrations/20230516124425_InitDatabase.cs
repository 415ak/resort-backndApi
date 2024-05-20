using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResortApiV2.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 19, 44, 25, 491, DateTimeKind.Local).AddTicks(7302));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2320));
        }
    }
}
