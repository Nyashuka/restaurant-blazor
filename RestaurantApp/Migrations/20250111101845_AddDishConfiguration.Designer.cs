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
    [Migration("20250111101845_AddDishConfiguration")]
    partial class AddDishConfiguration
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
                            PasswordHash = new byte[] { 237, 130, 22, 92, 146, 35, 140, 56, 118, 178, 202, 245, 220, 193, 200, 166, 144, 149, 171, 52, 172, 216, 197, 26, 159, 95, 119, 97, 103, 59, 101, 86, 164, 89, 46, 131, 192, 4, 204, 10, 156, 17, 64, 207, 145, 84, 4, 69, 47, 39, 92, 248, 32, 87, 165, 191, 101, 30, 166, 25, 164, 153, 117, 167 },
                            PasswordSalt = new byte[] { 166, 148, 120, 147, 205, 241, 111, 121, 211, 215, 183, 181, 51, 123, 146, 177, 163, 31, 202, 13, 210, 72, 186, 69, 107, 39, 144, 88, 145, 38, 182, 114, 116, 91, 84, 241, 100, 216, 40, 183, 117, 177, 118, 136, 77, 233, 114, 146, 136, 192, 221, 245, 2, 189, 132, 211, 10, 215, 179, 204, 197, 54, 133, 79, 156, 255, 239, 9, 221, 62, 150, 36, 220, 170, 147, 154, 46, 82, 125, 10, 84, 48, 127, 217, 25, 81, 86, 189, 138, 223, 239, 153, 117, 239, 110, 138, 245, 182, 190, 119, 32, 93, 242, 210, 216, 89, 62, 87, 222, 178, 139, 81, 186, 194, 68, 20, 209, 143, 78, 212, 57, 131, 237, 128, 237, 46, 130, 44 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 237, 130, 22, 92, 146, 35, 140, 56, 118, 178, 202, 245, 220, 193, 200, 166, 144, 149, 171, 52, 172, 216, 197, 26, 159, 95, 119, 97, 103, 59, 101, 86, 164, 89, 46, 131, 192, 4, 204, 10, 156, 17, 64, 207, 145, 84, 4, 69, 47, 39, 92, 248, 32, 87, 165, 191, 101, 30, 166, 25, 164, 153, 117, 167 },
                            PasswordSalt = new byte[] { 166, 148, 120, 147, 205, 241, 111, 121, 211, 215, 183, 181, 51, 123, 146, 177, 163, 31, 202, 13, 210, 72, 186, 69, 107, 39, 144, 88, 145, 38, 182, 114, 116, 91, 84, 241, 100, 216, 40, 183, 117, 177, 118, 136, 77, 233, 114, 146, 136, 192, 221, 245, 2, 189, 132, 211, 10, 215, 179, 204, 197, 54, 133, 79, 156, 255, 239, 9, 221, 62, 150, 36, 220, 170, 147, 154, 46, 82, 125, 10, 84, 48, 127, 217, 25, 81, 86, 189, 138, 223, 239, 153, 117, 239, 110, 138, 245, 182, 190, 119, 32, 93, 242, 210, 216, 89, 62, 87, 222, 178, 139, 81, 186, 194, 68, 20, 209, 143, 78, 212, 57, 131, 237, 128, 237, 46, 130, 44 },
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
#pragma warning restore 612, 618
        }
    }
}