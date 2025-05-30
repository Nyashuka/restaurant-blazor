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
    [Migration("20250314125959_AddDrinksAndFoodItemAndDrinkCategories")]
    partial class AddDrinksAndFoodItemAndDrinkCategories
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

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

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

                    b.Property<int>("DishId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

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

                    b.Property<int>("DishId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderDayId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderDayId");

                    b.ToTable("OrderMenuItems", (string)null);
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
                            PasswordHash = new byte[] { 219, 108, 74, 46, 222, 251, 152, 171, 184, 130, 10, 79, 81, 120, 68, 75, 2, 190, 96, 141, 106, 22, 243, 29, 108, 35, 94, 165, 153, 89, 165, 224, 104, 145, 67, 67, 168, 91, 226, 17, 213, 150, 79, 193, 236, 164, 11, 155, 224, 224, 180, 76, 66, 23, 19, 202, 9, 25, 202, 82, 159, 135, 83, 85 },
                            PasswordSalt = new byte[] { 144, 96, 117, 161, 241, 71, 84, 207, 1, 178, 158, 243, 59, 52, 112, 56, 223, 91, 139, 223, 107, 24, 153, 152, 77, 85, 160, 114, 160, 2, 9, 106, 185, 219, 172, 237, 99, 226, 195, 230, 61, 123, 152, 206, 111, 163, 123, 1, 53, 182, 217, 192, 245, 38, 97, 178, 235, 185, 245, 8, 61, 197, 167, 176, 115, 11, 87, 174, 6, 84, 28, 220, 216, 1, 80, 94, 187, 197, 116, 177, 230, 15, 183, 162, 178, 158, 159, 250, 40, 30, 236, 188, 195, 35, 33, 153, 61, 194, 149, 215, 242, 196, 177, 170, 73, 252, 138, 221, 179, 31, 143, 171, 199, 80, 73, 166, 192, 156, 145, 195, 199, 183, 144, 87, 48, 241, 251, 6 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 219, 108, 74, 46, 222, 251, 152, 171, 184, 130, 10, 79, 81, 120, 68, 75, 2, 190, 96, 141, 106, 22, 243, 29, 108, 35, 94, 165, 153, 89, 165, 224, 104, 145, 67, 67, 168, 91, 226, 17, 213, 150, 79, 193, 236, 164, 11, 155, 224, 224, 180, 76, 66, 23, 19, 202, 9, 25, 202, 82, 159, 135, 83, 85 },
                            PasswordSalt = new byte[] { 144, 96, 117, 161, 241, 71, 84, 207, 1, 178, 158, 243, 59, 52, 112, 56, 223, 91, 139, 223, 107, 24, 153, 152, 77, 85, 160, 114, 160, 2, 9, 106, 185, 219, 172, 237, 99, 226, 195, 230, 61, 123, 152, 206, 111, 163, 123, 1, 53, 182, 217, 192, 245, 38, 97, 178, 235, 185, 245, 8, 61, 197, 167, 176, 115, 11, 87, 174, 6, 84, 28, 220, 216, 1, 80, 94, 187, 197, 116, 177, 230, 15, 183, 162, 178, 158, 159, 250, 40, 30, 236, 188, 195, 35, 33, 153, 61, 194, 149, 215, 242, 196, 177, 170, 73, 252, 138, 221, 179, 31, 143, 171, 199, 80, 73, 166, 192, 156, 145, 195, 199, 183, 144, 87, 48, 241, 251, 6 },
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

                    b.Property<int>("DishCategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("RecommendedWeightPerPortion")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasIndex("DishCategoryId");

                    b.ToTable("Dishes", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Drink", b =>
                {
                    b.HasBaseType("RestaurantApp.Domain.Models.FoodItem");

                    b.Property<int>("DrinkCategoryId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("boolean");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.Property<int>("VolumePerPerson")
                        .HasColumnType("integer");

                    b.HasIndex("DrinkCategoryId");

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
                    b.HasOne("RestaurantApp.Domain.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.Menu", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

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
                    b.HasOne("RestaurantApp.Domain.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.OrderDay", "OrderDay")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("OrderDay");
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
                    b.HasOne("RestaurantApp.Domain.Models.DishCategory", "DishCategory")
                        .WithMany()
                        .HasForeignKey("DishCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.Dish", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishCategory");
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Drink", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.DrinkCategory", "DrinkCategory")
                        .WithMany()
                        .HasForeignKey("DrinkCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantApp.Domain.Models.FoodItem", null)
                        .WithOne()
                        .HasForeignKey("RestaurantApp.Domain.Models.Drink", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrinkCategory");
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
