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
    [Migration("20250104124702_AddDishTypeTable")]
    partial class AddDishTypeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                            PasswordHash = new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 },
                            PasswordSalt = new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 },
                            Role = 2
                        },
                        new
                        {
                            Id = 11,
                            Email = "manager@gmail.com",
                            FirstName = "Manager",
                            LastName = "",
                            PasswordHash = new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 },
                            PasswordSalt = new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 },
                            Role = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}