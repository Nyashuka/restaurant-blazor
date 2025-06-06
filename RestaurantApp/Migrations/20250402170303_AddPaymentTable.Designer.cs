﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RestaurantApp.Infrastructure.Persistence.DbContexts;

#nullable disable

namespace RestaurantApp.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20250402170303_AddPaymentTable")]
    partial class AddPaymentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RestaurantApp.Domain.Models.CategoryBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsShared")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("CategoryBase");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DishIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("DishIngredients", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodItems", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EventTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FoodItemId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItems", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.OrderDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDays", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.OrderMenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderDayId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("OrderDayId");

                    b.ToTable("OrderMenuItems", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AmountPaid")
                        .HasColumnType("double precision");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Email = "chief@gmail.com",
                            FirstName = "Chief",
                            LastName = "",
                            PasswordHash = new byte[] { 46, 31, 45, 183, 50, 74, 237, 57, 187, 77, 241, 22, 235, 33, 19, 181, 116, 18, 134, 184, 148, 181, 15, 205, 199, 106, 22, 200, 95, 196, 8, 56, 227, 112, 203, 86, 248, 195, 247, 197, 4, 170, 67, 202, 7, 31, 93, 56, 221, 170, 178, 223, 198, 175, 56, 180, 181, 56, 16, 125, 81, 92, 141, 245 },
                            PasswordSalt = new byte[] { 161, 125, 32, 44, 76, 43, 23, 252, 102, 7, 74, 105, 21, 109, 245, 159, 38, 251, 9, 21, 80, 253, 4, 152, 165, 200, 208, 159, 255, 67, 57, 222, 83, 105, 41, 48, 122, 243, 54, 29, 17, 152, 72, 203, 199, 109, 192, 223, 78, 189, 8, 249, 93, 240, 5, 104, 97, 125, 208, 158, 201, 157, 123, 121, 67, 34, 198, 133, 1, 83, 33, 25, 182, 171, 80, 48, 67, 181, 218, 203, 38, 22, 191, 126, 131, 86, 16, 117, 139, 102, 116, 226, 30, 42, 18, 58, 208, 8, 240, 176, 255, 184, 218, 48, 101, 83, 194, 179, 196, 136, 110, 98, 65, 59, 8, 168, 115, 119, 105, 189, 161, 251, 223, 157, 130, 209, 148, 57 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 46, 31, 45, 183, 50, 74, 237, 57, 187, 77, 241, 22, 235, 33, 19, 181, 116, 18, 134, 184, 148, 181, 15, 205, 199, 106, 22, 200, 95, 196, 8, 56, 227, 112, 203, 86, 248, 195, 247, 197, 4, 170, 67, 202, 7, 31, 93, 56, 221, 170, 178, 223, 198, 175, 56, 180, 181, 56, 16, 125, 81, 92, 141, 245 },
                            PasswordSalt = new byte[] { 161, 125, 32, 44, 76, 43, 23, 252, 102, 7, 74, 105, 21, 109, 245, 159, 38, 251, 9, 21, 80, 253, 4, 152, 165, 200, 208, 159, 255, 67, 57, 222, 83, 105, 41, 48, 122, 243, 54, 29, 17, 152, 72, 203, 199, 109, 192, 223, 78, 189, 8, 249, 93, 240, 5, 104, 97, 125, 208, 158, 201, 157, 123, 121, 67, 34, 198, 133, 1, 83, 33, 25, 182, 171, 80, 48, 67, 181, 218, 203, 38, 22, 191, 126, 131, 86, 16, 117, 139, 102, 116, 226, 30, 42, 18, 58, 208, 8, 240, 176, 255, 184, 218, 48, 101, 83, 194, 179, 196, 136, 110, 98, 65, 59, 8, 168, 115, 119, 105, 189, 161, 251, 223, 157, 130, 209, 148, 57 },
                            Role = 3
                        });
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DishCategory", b =>
                {
                    b.HasBaseType("RestaurantApp.Domain.Models.CategoryBase");

                    b.ToTable("DishCategories", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DrinkCategory", b =>
                {
                    b.HasBaseType("RestaurantApp.Domain.Models.CategoryBase");

                    b.ToTable("DrinkCategories", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Dish", b =>
                {
                    b.HasBaseType("RestaurantApp.Domain.Models.FoodItem");

                    b.Property<int>("RecommendedWeightPerPortion")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.ToTable("Dishes", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Drink", b =>
                {
                    b.HasBaseType("RestaurantApp.Domain.Models.FoodItem");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("boolean");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.Property<int>("VolumePerPerson")
                        .HasColumnType("integer");

                    b.ToTable("Drinks", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DishIngredient", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.FoodItem", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.CategoryBase", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Menu", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.MenuItem", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Order", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.OrderDay", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.Order", "Order")
                        .WithMany("OrderDays")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.OrderMenuItem", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.OrderDay", "OrderDay")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("OrderDay");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Payment", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DishCategory", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.CategoryBase", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.DishCategory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.DrinkCategory", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.CategoryBase", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.DrinkCategory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Dish", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.Dish", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Drink", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.Drink", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Menu", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderDays");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.OrderDay", b =>
                {
                    b.Navigation("OrderMenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}
