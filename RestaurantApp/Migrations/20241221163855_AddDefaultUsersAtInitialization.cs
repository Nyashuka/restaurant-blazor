﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultUsersAtInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[,]
                {
                    { 10, "chief@gmail.com", "Chief", "", new byte[] { 4, 206, 134, 111, 77, 208, 38, 8, 159, 160, 127, 83, 231, 221, 155, 77, 54, 39, 21, 184, 162, 99, 217, 149, 121, 155, 62, 200, 237, 101, 238, 164, 126, 120, 1, 129, 45, 155, 141, 86, 61, 195, 250, 54, 229, 21, 205, 71, 3, 160, 5, 45, 155, 230, 166, 188, 231, 47, 62, 252, 57, 252, 223, 36 }, new byte[] { 153, 226, 207, 192, 222, 73, 183, 184, 120, 135, 191, 211, 139, 63, 159, 187, 138, 37, 6, 181, 155, 157, 164, 211, 234, 130, 160, 254, 184, 172, 168, 41, 181, 14, 28, 166, 119, 138, 27, 8, 123, 41, 250, 74, 225, 137, 79, 136, 149, 248, 246, 171, 5, 69, 29, 125, 131, 110, 126, 75, 123, 163, 184, 92, 169, 86, 33, 96, 126, 96, 23, 207, 193, 252, 183, 46, 241, 60, 245, 115, 189, 121, 162, 179, 20, 102, 200, 206, 82, 217, 105, 18, 45, 79, 121, 202, 226, 123, 69, 195, 20, 67, 11, 42, 66, 177, 136, 61, 211, 78, 134, 15, 116, 43, 51, 82, 78, 108, 208, 207, 47, 220, 113, 71, 29, 229, 236, 123 }, 2 },
                    { 11, "manager@gmail.com", "Manager", "", new byte[] { 4, 206, 134, 111, 77, 208, 38, 8, 159, 160, 127, 83, 231, 221, 155, 77, 54, 39, 21, 184, 162, 99, 217, 149, 121, 155, 62, 200, 237, 101, 238, 164, 126, 120, 1, 129, 45, 155, 141, 86, 61, 195, 250, 54, 229, 21, 205, 71, 3, 160, 5, 45, 155, 230, 166, 188, 231, 47, 62, 252, 57, 252, 223, 36 }, new byte[] { 153, 226, 207, 192, 222, 73, 183, 184, 120, 135, 191, 211, 139, 63, 159, 187, 138, 37, 6, 181, 155, 157, 164, 211, 234, 130, 160, 254, 184, 172, 168, 41, 181, 14, 28, 166, 119, 138, 27, 8, 123, 41, 250, 74, 225, 137, 79, 136, 149, 248, 246, 171, 5, 69, 29, 125, 131, 110, 126, 75, 123, 163, 184, 92, 169, 86, 33, 96, 126, 96, 23, 207, 193, 252, 183, 46, 241, 60, 245, 115, 189, 121, 162, 179, 20, 102, 200, 206, 82, 217, 105, 18, 45, 79, 121, 202, 226, 123, 69, 195, 20, 67, 11, 42, 66, 177, 136, 61, 211, 78, 134, 15, 116, 43, 51, 82, 78, 108, 208, 207, 47, 220, 113, 71, 29, 229, 236, 123 }, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}