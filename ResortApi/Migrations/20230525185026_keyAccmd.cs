using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResortApiV2.Migrations
{
    public partial class keyAccmd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "CreateData",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "CreateData",
                value: new DateTime(2023, 5, 26, 1, 50, 26, 404, DateTimeKind.Local).AddTicks(4697));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "AccommodationTypes",
                keyColumn: "AccommodationTypeId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "1",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "2",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "3",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "4",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "5",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "FdCategories",
                keyColumn: "FdCategoryId",
                keyValue: "6",
                column: "DateTime",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "1",
                column: "CreateData",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "2",
                column: "CreateData",
                value: new DateTime(2023, 5, 25, 5, 15, 8, 177, DateTimeKind.Local).AddTicks(8412));
        }
    }
}
