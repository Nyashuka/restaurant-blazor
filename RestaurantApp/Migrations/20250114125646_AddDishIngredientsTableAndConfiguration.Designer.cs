﻿// <auto-generated />
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
    [Migration("20250114125646_AddDishIngredientsTableAndConfiguration")]
    partial class AddDishIngredientsTableAndConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RestaurantApp.Domain.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DishTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("double precision");

                    b.Property<int>("ServingPerUnit")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DishTypeId");

                    b.ToTable("Dishes", (string)null);
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

            modelBuilder.Entity("RestaurantApp.Domain.Models.DishType", b =>
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

                    b.ToTable("DishTypes", (string)null);
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
                            PasswordHash = new byte[] { 220, 196, 93, 76, 133, 194, 112, 182, 240, 238, 123, 160, 250, 29, 33, 150, 189, 91, 129, 58, 28, 2, 227, 30, 232, 97, 140, 93, 149, 159, 173, 152, 182, 30, 166, 22, 160, 46, 11, 3, 107, 161, 4, 158, 213, 59, 138, 244, 221, 123, 55, 167, 109, 219, 161, 71, 73, 189, 194, 94, 156, 52, 7, 161 },
                            PasswordSalt = new byte[] { 47, 240, 232, 117, 186, 206, 245, 163, 46, 42, 215, 42, 233, 205, 124, 59, 194, 31, 249, 136, 11, 242, 67, 88, 176, 183, 153, 169, 181, 246, 172, 30, 156, 247, 195, 115, 101, 78, 185, 203, 239, 77, 48, 221, 224, 98, 93, 183, 188, 47, 33, 100, 104, 134, 55, 111, 111, 182, 110, 226, 40, 138, 92, 156, 168, 99, 173, 154, 108, 71, 118, 210, 242, 229, 80, 96, 228, 169, 201, 129, 145, 6, 211, 150, 36, 226, 180, 56, 83, 113, 227, 74, 250, 85, 131, 113, 20, 236, 214, 166, 241, 212, 56, 230, 129, 57, 190, 83, 141, 86, 204, 37, 69, 0, 91, 215, 146, 247, 214, 145, 118, 50, 49, 78, 41, 75, 165, 186 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 220, 196, 93, 76, 133, 194, 112, 182, 240, 238, 123, 160, 250, 29, 33, 150, 189, 91, 129, 58, 28, 2, 227, 30, 232, 97, 140, 93, 149, 159, 173, 152, 182, 30, 166, 22, 160, 46, 11, 3, 107, 161, 4, 158, 213, 59, 138, 244, 221, 123, 55, 167, 109, 219, 161, 71, 73, 189, 194, 94, 156, 52, 7, 161 },
                            PasswordSalt = new byte[] { 47, 240, 232, 117, 186, 206, 245, 163, 46, 42, 215, 42, 233, 205, 124, 59, 194, 31, 249, 136, 11, 242, 67, 88, 176, 183, 153, 169, 181, 246, 172, 30, 156, 247, 195, 115, 101, 78, 185, 203, 239, 77, 48, 221, 224, 98, 93, 183, 188, 47, 33, 100, 104, 134, 55, 111, 111, 182, 110, 226, 40, 138, 92, 156, 168, 99, 173, 154, 108, 71, 118, 210, 242, 229, 80, 96, 228, 169, 201, 129, 145, 6, 211, 150, 36, 226, 180, 56, 83, 113, 227, 74, 250, 85, 131, 113, 20, 236, 214, 166, 241, 212, 56, 230, 129, 57, 190, 83, 141, 86, 204, 37, 69, 0, 91, 215, 146, 247, 214, 145, 118, 50, 49, 78, 41, 75, 165, 186 },
                            Role = 3
                        });
                });

            modelBuilder.Entity("RestaurantApp.Domain.Models.Dish", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Models.DishType", "DishType")
                        .WithMany()
                        .HasForeignKey("DishTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishType");
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
#pragma warning restore 612, 618
        }
    }
}