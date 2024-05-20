﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResortApi.Models.Data;

#nullable disable

namespace ResortApiV2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230516114049_InitV2")]
    partial class InitV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ResortApi.Models.Accommodation", b =>
                {
                    b.Property<string>("AccommodationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccommodationTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccommodationId");

                    b.HasIndex("AccommodationTypeId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("ResortApi.Models.AccommodationImg", b =>
                {
                    b.Property<Guid>("AccommodationImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccommodationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccommodationImgId");

                    b.HasIndex("AccommodationId");

                    b.ToTable("AccommodationImgs");
                });

            modelBuilder.Entity("ResortApi.Models.AccommodationType", b =>
                {
                    b.Property<string>("AccommodationTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccommodationTypeId");

                    b.ToTable("AccommodationTypes");

                    b.HasData(
                        new
                        {
                            AccommodationTypeId = "1",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2431),
                            IsUsed = 1,
                            Name = "บ้านเดี่ยว"
                        },
                        new
                        {
                            AccommodationTypeId = "2",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2432),
                            IsUsed = 1,
                            Name = "บ้าน2ชั้น"
                        },
                        new
                        {
                            AccommodationTypeId = "3",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2433),
                            IsUsed = 1,
                            Name = "อาคารตึก"
                        },
                        new
                        {
                            AccommodationTypeId = "4",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2434),
                            IsUsed = 1,
                            Name = "บ้านแพ"
                        },
                        new
                        {
                            AccommodationTypeId = "5",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2435),
                            IsUsed = 1,
                            Name = "พื้นที่กางเต็น"
                        },
                        new
                        {
                            AccommodationTypeId = "6",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2436),
                            IsUsed = 1,
                            Name = "อื่นๆ"
                        });
                });

            modelBuilder.Entity("ResortApi.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ResortApi.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FdId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ResortApi.Models.FdCategory", b =>
                {
                    b.Property<string>("FdCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FdCategoryId");

                    b.ToTable("FdCategories");

                    b.HasData(
                        new
                        {
                            FdCategoryId = "1",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2409),
                            IsUsed = 1,
                            Name = "แกง-ต้ม"
                        },
                        new
                        {
                            FdCategoryId = "2",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2411),
                            IsUsed = 1,
                            Name = "ของทอด-ผัด"
                        },
                        new
                        {
                            FdCategoryId = "3",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2411),
                            IsUsed = 1,
                            Name = "ยำ-สลัด"
                        },
                        new
                        {
                            FdCategoryId = "4",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2412),
                            IsUsed = 1,
                            Name = "ของหวาน"
                        },
                        new
                        {
                            FdCategoryId = "5",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2413),
                            IsUsed = 1,
                            Name = "เครื่องดื่ม"
                        },
                        new
                        {
                            FdCategoryId = "6",
                            DateTime = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2413),
                            IsUsed = 1,
                            Name = "อื่นๆ"
                        });
                });

            modelBuilder.Entity("ResortApi.Models.FdImg", b =>
                {
                    b.Property<Guid>("FdImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FdImgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodDrinkFdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FdImgId");

                    b.HasIndex("FoodDrinkFdId");

                    b.ToTable("FdImgs");
                });

            modelBuilder.Entity("ResortApi.Models.FoodDrink", b =>
                {
                    b.Property<string>("FdId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FdCategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FdDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FdIsused")
                        .HasColumnType("int");

                    b.Property<string>("FdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FdPrice")
                        .HasColumnType("int");

                    b.HasKey("FdId");

                    b.HasIndex("FdCategoryId");

                    b.ToTable("FoodDrinks");
                });

            modelBuilder.Entity("ResortApi.Models.HBOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isused")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("HBOrders");
                });

            modelBuilder.Entity("ResortApi.Models.HBOrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccommodationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesiredDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HBOrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("HBOrderId");

                    b.ToTable("HBOrderItems");
                });

            modelBuilder.Entity("ResortApi.Models.HouseBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccommodationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesiredDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("HouseBookings");
                });

            modelBuilder.Entity("ResortApi.Models.Information", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgInform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Information");
                });

            modelBuilder.Entity("ResortApi.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccommodationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DelStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isused")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ResortApi.Models.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("FdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FdId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ResortApi.Models.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Createdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HbOrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServeOrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ResortApi.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateData")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleIsused")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = "1",
                            CreateData = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2309),
                            RoleIsused = "1",
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = "2",
                            CreateData = new DateTime(2023, 5, 16, 18, 40, 49, 171, DateTimeKind.Local).AddTicks(2320),
                            RoleIsused = "1",
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("ResortApi.Models.SecurityUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TruePassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("SecurityUsers");
                });

            modelBuilder.Entity("ResortApi.Models.Serve", b =>
                {
                    b.Property<int>("ServeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServeId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ServeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ResortApi.Models.ServeCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServeId");

                    b.ToTable("ServeCarts");
                });

            modelBuilder.Entity("ResortApi.Models.ServeImg", b =>
                {
                    b.Property<Guid>("ServeImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsUsed")
                        .HasColumnType("int");

                    b.Property<int>("ServeId")
                        .HasColumnType("int");

                    b.HasKey("ServeImgId");

                    b.HasIndex("ServeId");

                    b.ToTable("ServiceImgs");
                });

            modelBuilder.Entity("ResortApi.Models.ServeOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isused")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("ServeOrders");
                });

            modelBuilder.Entity("ResortApi.Models.ServeOrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ServeId")
                        .HasColumnType("int");

                    b.Property<string>("ServeOrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ServeId");

                    b.HasIndex("ServeOrderId");

                    b.ToTable("ServeOrdersItem");
                });

            modelBuilder.Entity("ResortApi.Models.ServeType", b =>
                {
                    b.Property<string>("ServeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServeTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("ResortApi.Models.Accommodation", b =>
                {
                    b.HasOne("ResortApi.Models.AccommodationType", "AccommodationType")
                        .WithMany()
                        .HasForeignKey("AccommodationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccommodationType");
                });

            modelBuilder.Entity("ResortApi.Models.AccommodationImg", b =>
                {
                    b.HasOne("ResortApi.Models.Accommodation", null)
                        .WithMany("AccommodationImgs")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResortApi.Models.Account", b =>
                {
                    b.HasOne("ResortApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ResortApi.Models.CartItem", b =>
                {
                    b.HasOne("ResortApi.Models.FoodDrink", "FoodDrink")
                        .WithMany()
                        .HasForeignKey("FdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodDrink");
                });

            modelBuilder.Entity("ResortApi.Models.FdImg", b =>
                {
                    b.HasOne("ResortApi.Models.FoodDrink", null)
                        .WithMany("FdImgs")
                        .HasForeignKey("FoodDrinkFdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResortApi.Models.FoodDrink", b =>
                {
                    b.HasOne("ResortApi.Models.FdCategory", "FdCategory")
                        .WithMany()
                        .HasForeignKey("FdCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FdCategory");
                });

            modelBuilder.Entity("ResortApi.Models.HBOrder", b =>
                {
                    b.HasOne("ResortApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ResortApi.Models.HBOrderItem", b =>
                {
                    b.HasOne("ResortApi.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResortApi.Models.HBOrder", null)
                        .WithMany("HBOrderItem")
                        .HasForeignKey("HBOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("ResortApi.Models.HouseBooking", b =>
                {
                    b.HasOne("ResortApi.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("ResortApi.Models.Order", b =>
                {
                    b.HasOne("ResortApi.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResortApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ResortApi.Models.OrderItem", b =>
                {
                    b.HasOne("ResortApi.Models.FoodDrink", "FoodDrink")
                        .WithMany()
                        .HasForeignKey("FdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResortApi.Models.Order", null)
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodDrink");
                });

            modelBuilder.Entity("ResortApi.Models.Payment", b =>
                {
                    b.HasOne("ResortApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ResortApi.Models.ServeCart", b =>
                {
                    b.HasOne("ResortApi.Models.Serve", "Serve")
                        .WithMany()
                        .HasForeignKey("ServeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serve");
                });

            modelBuilder.Entity("ResortApi.Models.ServeImg", b =>
                {
                    b.HasOne("ResortApi.Models.Serve", null)
                        .WithMany("ServeImgs")
                        .HasForeignKey("ServeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResortApi.Models.ServeOrder", b =>
                {
                    b.HasOne("ResortApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ResortApi.Models.ServeOrderItem", b =>
                {
                    b.HasOne("ResortApi.Models.Serve", "Serve")
                        .WithMany()
                        .HasForeignKey("ServeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResortApi.Models.ServeOrder", null)
                        .WithMany("ServeOrderItem")
                        .HasForeignKey("ServeOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serve");
                });

            modelBuilder.Entity("ResortApi.Models.Accommodation", b =>
                {
                    b.Navigation("AccommodationImgs");
                });

            modelBuilder.Entity("ResortApi.Models.FoodDrink", b =>
                {
                    b.Navigation("FdImgs");
                });

            modelBuilder.Entity("ResortApi.Models.HBOrder", b =>
                {
                    b.Navigation("HBOrderItem");
                });

            modelBuilder.Entity("ResortApi.Models.Order", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("ResortApi.Models.Serve", b =>
                {
                    b.Navigation("ServeImgs");
                });

            modelBuilder.Entity("ResortApi.Models.ServeOrder", b =>
                {
                    b.Navigation("ServeOrderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
