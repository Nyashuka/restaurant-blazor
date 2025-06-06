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
    [Migration("20250425125446_fixDefaultValuesForISEnabled")]
    partial class fixDefaultValuesForISEnabled
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

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

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

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

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

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

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

                    b.HasIndex("UserId");

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
                            PasswordHash = new byte[] { 85, 105, 145, 102, 167, 126, 63, 93, 81, 33, 60, 169, 93, 167, 116, 181, 115, 253, 199, 246, 76, 28, 169, 154, 117, 197, 62, 0, 222, 27, 13, 244, 193, 122, 70, 140, 172, 79, 177, 159, 179, 186, 249, 41, 172, 92, 73, 55, 249, 108, 125, 6, 249, 128, 74, 213, 216, 13, 24, 253, 148, 235, 214, 94 },
                            PasswordSalt = new byte[] { 231, 204, 201, 22, 242, 191, 82, 174, 244, 34, 78, 248, 167, 64, 205, 70, 21, 28, 20, 211, 137, 176, 22, 209, 209, 37, 210, 0, 112, 187, 228, 72, 199, 5, 4, 154, 251, 233, 90, 200, 184, 76, 45, 136, 209, 27, 249, 222, 33, 80, 38, 49, 205, 122, 161, 235, 36, 104, 127, 234, 173, 205, 189, 35, 235, 148, 170, 196, 65, 196, 140, 61, 54, 47, 13, 15, 164, 128, 118, 91, 151, 73, 101, 168, 244, 114, 202, 205, 173, 33, 17, 88, 135, 230, 237, 30, 135, 218, 140, 30, 230, 140, 11, 220, 41, 188, 45, 51, 126, 228, 240, 29, 55, 99, 172, 254, 191, 12, 62, 0, 137, 90, 155, 211, 119, 197, 214, 8 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 85, 105, 145, 102, 167, 126, 63, 93, 81, 33, 60, 169, 93, 167, 116, 181, 115, 253, 199, 246, 76, 28, 169, 154, 117, 197, 62, 0, 222, 27, 13, 244, 193, 122, 70, 140, 172, 79, 177, 159, 179, 186, 249, 41, 172, 92, 73, 55, 249, 108, 125, 6, 249, 128, 74, 213, 216, 13, 24, 253, 148, 235, 214, 94 },
                            PasswordSalt = new byte[] { 231, 204, 201, 22, 242, 191, 82, 174, 244, 34, 78, 248, 167, 64, 205, 70, 21, 28, 20, 211, 137, 176, 22, 209, 209, 37, 210, 0, 112, 187, 228, 72, 199, 5, 4, 154, 251, 233, 90, 200, 184, 76, 45, 136, 209, 27, 249, 222, 33, 80, 38, 49, 205, 122, 161, 235, 36, 104, 127, 234, 173, 205, 189, 35, 235, 148, 170, 196, 65, 196, 140, 61, 54, 47, 13, 15, 164, 128, 118, 91, 151, 73, 101, 168, 244, 114, 202, 205, 173, 33, 17, 88, 135, 230, 237, 30, 135, 218, 140, 30, 230, 140, 11, 220, 41, 188, 45, 51, 126, 228, 240, 29, 55, 99, 172, 254, 191, 12, 62, 0, 137, 90, 155, 211, 119, 197, 214, 8 },
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

                    b.HasOne("RestaurantApp.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("User");
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
