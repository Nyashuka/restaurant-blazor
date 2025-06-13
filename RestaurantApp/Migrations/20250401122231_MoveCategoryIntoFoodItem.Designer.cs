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
    [Migration("20250401122231_MoveCategoryIntoFoodItem")]
    partial class MoveCategoryIntoFoodItem
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
                            PasswordHash = new byte[] { 220, 136, 25, 183, 21, 13, 94, 184, 95, 63, 8, 59, 41, 107, 93, 15, 203, 173, 112, 15, 188, 84, 49, 140, 242, 128, 153, 114, 59, 15, 91, 165, 200, 5, 94, 207, 108, 186, 215, 13, 34, 20, 118, 10, 58, 183, 196, 147, 197, 44, 52, 64, 128, 24, 1, 51, 93, 199, 201, 85, 15, 223, 124, 175 },
                            PasswordSalt = new byte[] { 9, 218, 127, 108, 77, 144, 219, 88, 112, 20, 192, 92, 21, 177, 229, 143, 193, 29, 171, 12, 71, 103, 108, 122, 190, 185, 201, 198, 204, 99, 252, 112, 104, 164, 232, 228, 133, 102, 94, 89, 57, 24, 189, 46, 86, 254, 126, 135, 160, 177, 247, 206, 148, 97, 195, 235, 41, 45, 255, 5, 160, 99, 187, 174, 167, 152, 53, 254, 91, 220, 206, 10, 104, 34, 182, 89, 2, 161, 75, 196, 62, 239, 89, 225, 44, 230, 201, 237, 180, 5, 161, 18, 145, 221, 42, 3, 149, 35, 61, 161, 39, 101, 250, 43, 247, 132, 192, 250, 72, 183, 198, 46, 57, 79, 93, 82, 195, 86, 222, 129, 118, 16, 189, 29, 8, 178, 47, 117 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 220, 136, 25, 183, 21, 13, 94, 184, 95, 63, 8, 59, 41, 107, 93, 15, 203, 173, 112, 15, 188, 84, 49, 140, 242, 128, 153, 114, 59, 15, 91, 165, 200, 5, 94, 207, 108, 186, 215, 13, 34, 20, 118, 10, 58, 183, 196, 147, 197, 44, 52, 64, 128, 24, 1, 51, 93, 199, 201, 85, 15, 223, 124, 175 },
                            PasswordSalt = new byte[] { 9, 218, 127, 108, 77, 144, 219, 88, 112, 20, 192, 92, 21, 177, 229, 143, 193, 29, 171, 12, 71, 103, 108, 122, 190, 185, 201, 198, 204, 99, 252, 112, 104, 164, 232, 228, 133, 102, 94, 89, 57, 24, 189, 46, 86, 254, 126, 135, 160, 177, 247, 206, 148, 97, 195, 235, 41, 45, 255, 5, 160, 99, 187, 174, 167, 152, 53, 254, 91, 220, 206, 10, 104, 34, 182, 89, 2, 161, 75, 196, 62, 239, 89, 225, 44, 230, 201, 237, 180, 5, 161, 18, 145, 221, 42, 3, 149, 35, 61, 161, 39, 101, 250, 43, 247, 132, 192, 250, 72, 183, 198, 46, 57, 79, 93, 82, 195, 86, 222, 129, 118, 16, 189, 29, 8, 178, 47, 117 },
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
