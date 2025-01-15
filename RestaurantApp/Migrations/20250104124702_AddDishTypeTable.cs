﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDishTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 }, new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 }, new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 167, 117, 38, 192, 92, 100, 24, 175, 182, 246, 135, 198, 82, 150, 241, 29, 165, 71, 231, 162, 79, 255, 116, 98, 126, 228, 234, 220, 141, 129, 223, 151, 123, 103, 45, 235, 23, 51, 39, 46, 121, 19, 10, 147, 243, 242, 19, 116, 123, 95, 32, 254, 216, 152, 211, 94, 128, 137, 204, 101, 215, 179, 108, 150 }, new byte[] { 164, 253, 247, 203, 1, 31, 22, 232, 184, 216, 33, 189, 173, 17, 121, 194, 26, 117, 116, 73, 254, 137, 116, 122, 10, 143, 203, 102, 151, 220, 144, 186, 157, 72, 178, 47, 225, 142, 168, 103, 167, 236, 87, 112, 185, 189, 40, 94, 207, 86, 65, 79, 62, 96, 237, 22, 122, 222, 10, 114, 53, 33, 131, 95, 235, 79, 218, 177, 15, 28, 55, 163, 183, 5, 59, 214, 182, 36, 246, 162, 18, 109, 203, 146, 247, 6, 2, 200, 43, 40, 238, 170, 110, 114, 208, 244, 53, 77, 40, 147, 236, 208, 84, 76, 179, 212, 27, 229, 171, 68, 107, 119, 229, 19, 144, 13, 85, 151, 147, 246, 225, 177, 1, 33, 136, 173, 224, 238 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 167, 117, 38, 192, 92, 100, 24, 175, 182, 246, 135, 198, 82, 150, 241, 29, 165, 71, 231, 162, 79, 255, 116, 98, 126, 228, 234, 220, 141, 129, 223, 151, 123, 103, 45, 235, 23, 51, 39, 46, 121, 19, 10, 147, 243, 242, 19, 116, 123, 95, 32, 254, 216, 152, 211, 94, 128, 137, 204, 101, 215, 179, 108, 150 }, new byte[] { 164, 253, 247, 203, 1, 31, 22, 232, 184, 216, 33, 189, 173, 17, 121, 194, 26, 117, 116, 73, 254, 137, 116, 122, 10, 143, 203, 102, 151, 220, 144, 186, 157, 72, 178, 47, 225, 142, 168, 103, 167, 236, 87, 112, 185, 189, 40, 94, 207, 86, 65, 79, 62, 96, 237, 22, 122, 222, 10, 114, 53, 33, 131, 95, 235, 79, 218, 177, 15, 28, 55, 163, 183, 5, 59, 214, 182, 36, 246, 162, 18, 109, 203, 146, 247, 6, 2, 200, 43, 40, 238, 170, 110, 114, 208, 244, 53, 77, 40, 147, 236, 208, 84, 76, 179, 212, 27, 229, 171, 68, 107, 119, 229, 19, 144, 13, 85, 151, 147, 246, 225, 177, 1, 33, 136, 173, 224, 238 } });
        }
    }
}