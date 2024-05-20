using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResortApiV2.Migrations
{
    public partial class InitV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "CreateData",
                value: new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(295));
        }
    }
}
