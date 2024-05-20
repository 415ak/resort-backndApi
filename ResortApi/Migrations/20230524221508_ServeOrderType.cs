using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResortApiV2.Migrations
{
    public partial class ServeOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ServeOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ServeOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
