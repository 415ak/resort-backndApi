using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResortApiV2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationTypes",
                columns: table => new
                {
                    AccommodationTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationTypes", x => x.AccommodationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FdCategories",
                columns: table => new
                {
                    FdCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FdCategories", x => x.FdCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgInform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleIsused = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SecurityUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TruePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServeTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccommodationTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
                    table.ForeignKey(
                        name: "FK_Accommodations_AccommodationTypes_AccommodationTypeId",
                        column: x => x.AccommodationTypeId,
                        principalTable: "AccommodationTypes",
                        principalColumn: "AccommodationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDrinks",
                columns: table => new
                {
                    FdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FdPrice = table.Column<int>(type: "int", nullable: false),
                    FdIsused = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FdCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDrinks", x => x.FdId);
                    table.ForeignKey(
                        name: "FK_FoodDrinks_FdCategories_FdCategoryId",
                        column: x => x.FdCategoryId,
                        principalTable: "FdCategories",
                        principalColumn: "FdCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServeCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServeCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServeCarts_Services_ServeId",
                        column: x => x.ServeId,
                        principalTable: "Services",
                        principalColumn: "ServeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceImgs",
                columns: table => new
                {
                    ServeImgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceImgs", x => x.ServeImgId);
                    table.ForeignKey(
                        name: "FK_ServiceImgs_Services_ServeId",
                        column: x => x.ServeId,
                        principalTable: "Services",
                        principalColumn: "ServeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationImgs",
                columns: table => new
                {
                    AccommodationImgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccommodationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImgs", x => x.AccommodationImgId);
                    table.ForeignKey(
                        name: "FK_AccommodationImgs_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesiredDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseBookings_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_FoodDrinks_FdId",
                        column: x => x.FdId,
                        principalTable: "FoodDrinks",
                        principalColumn: "FdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FdImgs",
                columns: table => new
                {
                    FdImgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FdImgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FoodDrinkFdId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FdImgs", x => x.FdImgId);
                    table.ForeignKey(
                        name: "FK_FdImgs_FoodDrinks_FoodDrinkFdId",
                        column: x => x.FoodDrinkFdId,
                        principalTable: "FoodDrinks",
                        principalColumn: "FdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HBOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isused = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HBOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HBOrders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccommodationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isused = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImgPay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HbOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServeOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServeOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isused = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServeOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServeOrders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HBOrderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesiredDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HBOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccommodationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HBOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HBOrderItems_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HBOrderItems_HBOrders_HBOrderId",
                        column: x => x.HBOrderId,
                        principalTable: "HBOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_FoodDrinks_FdId",
                        column: x => x.FdId,
                        principalTable: "FoodDrinks",
                        principalColumn: "FdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServeOrdersItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServeOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServeOrdersItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServeOrdersItem_ServeOrders_ServeOrderId",
                        column: x => x.ServeOrderId,
                        principalTable: "ServeOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServeOrdersItem_Services_ServeId",
                        column: x => x.ServeId,
                        principalTable: "Services",
                        principalColumn: "ServeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccommodationTypes",
                columns: new[] { "AccommodationTypeId", "DateTime", "IsUsed", "Name" },
                values: new object[,]
                {
                    { "1", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(542), 1, "บ้านเดี่ยว" },
                    { "2", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(544), 1, "บ้าน2ชั้น" },
                    { "3", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(545), 1, "อาคารตึก" },
                    { "4", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(546), 1, "บ้านแพ" },
                    { "5", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(546), 1, "พื้นที่กางเต็น" },
                    { "6", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(548), 1, "อื่นๆ" }
                });

            migrationBuilder.InsertData(
                table: "FdCategories",
                columns: new[] { "FdCategoryId", "DateTime", "IsUsed", "Name" },
                values: new object[,]
                {
                    { "1", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(518), 1, "แกง-ต้ม" },
                    { "2", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(519), 1, "ของทอด-ผัด" },
                    { "3", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(520), 1, "ยำ-สลัด" },
                    { "4", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(521), 1, "ของหวาน" },
                    { "5", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(521), 1, "เครื่องดื่ม" },
                    { "6", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(522), 1, "อื่นๆ" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreateData", "RoleIsused", "RoleName" },
                values: new object[,]
                {
                    { "1", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(284), "1", "User" },
                    { "2", new DateTime(2023, 5, 16, 18, 31, 54, 810, DateTimeKind.Local).AddTicks(295), "1", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImgs_AccommodationId",
                table: "AccommodationImgs",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AccommodationTypeId",
                table: "Accommodations",
                column: "AccommodationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FdId",
                table: "CartItems",
                column: "FdId");

            migrationBuilder.CreateIndex(
                name: "IX_FdImgs_FoodDrinkFdId",
                table: "FdImgs",
                column: "FoodDrinkFdId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDrinks_FdCategoryId",
                table: "FoodDrinks",
                column: "FdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HBOrderItems_AccommodationId",
                table: "HBOrderItems",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_HBOrderItems_HBOrderId",
                table: "HBOrderItems",
                column: "HBOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HBOrders_AccountId",
                table: "HBOrders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseBookings_AccommodationId",
                table: "HouseBookings",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FdId",
                table: "OrderItems",
                column: "FdId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccommodationId",
                table: "Orders",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountId",
                table: "Payments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ServeCarts_ServeId",
                table: "ServeCarts",
                column: "ServeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServeOrders_AccountId",
                table: "ServeOrders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ServeOrdersItem_ServeId",
                table: "ServeOrdersItem",
                column: "ServeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServeOrdersItem_ServeOrderId",
                table: "ServeOrdersItem",
                column: "ServeOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceImgs_ServeId",
                table: "ServiceImgs",
                column: "ServeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImgs");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "FdImgs");

            migrationBuilder.DropTable(
                name: "HBOrderItems");

            migrationBuilder.DropTable(
                name: "HouseBookings");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SecurityUsers");

            migrationBuilder.DropTable(
                name: "ServeCarts");

            migrationBuilder.DropTable(
                name: "ServeOrdersItem");

            migrationBuilder.DropTable(
                name: "ServiceImgs");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "HBOrders");

            migrationBuilder.DropTable(
                name: "FoodDrinks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ServeOrders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "FdCategories");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccommodationTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
