﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSharedFieldInDishType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "DishTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 112, 229, 224, 195, 240, 58, 43, 143, 172, 192, 244, 205, 103, 27, 50, 7, 216, 210, 139, 4, 156, 18, 115, 24, 52, 157, 226, 180, 73, 95, 131, 250, 203, 209, 173, 110, 92, 87, 86, 131, 121, 138, 217, 230, 211, 123, 166, 216, 220, 91, 179, 106, 123, 149, 59, 226, 136, 141, 70, 152, 9, 63, 73 }, new byte[] { 207, 154, 70, 189, 188, 31, 87, 140, 146, 29, 18, 205, 145, 240, 106, 183, 33, 91, 189, 133, 75, 32, 222, 251, 21, 85, 151, 160, 13, 92, 255, 209, 35, 44, 1, 184, 117, 95, 61, 202, 184, 41, 183, 65, 205, 182, 72, 14, 230, 240, 63, 24, 37, 26, 34, 172, 3, 44, 72, 87, 39, 90, 117, 140, 155, 248, 60, 34, 234, 116, 46, 227, 36, 247, 86, 2, 86, 226, 123, 157, 76, 200, 21, 56, 255, 158, 253, 200, 88, 243, 227, 43, 35, 60, 24, 48, 146, 12, 45, 83, 212, 136, 57, 45, 1, 6, 219, 165, 148, 153, 245, 84, 91, 243, 202, 13, 206, 112, 171, 89, 6, 144, 158, 34, 161, 189, 161, 30 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 112, 229, 224, 195, 240, 58, 43, 143, 172, 192, 244, 205, 103, 27, 50, 7, 216, 210, 139, 4, 156, 18, 115, 24, 52, 157, 226, 180, 73, 95, 131, 250, 203, 209, 173, 110, 92, 87, 86, 131, 121, 138, 217, 230, 211, 123, 166, 216, 220, 91, 179, 106, 123, 149, 59, 226, 136, 141, 70, 152, 9, 63, 73 }, new byte[] { 207, 154, 70, 189, 188, 31, 87, 140, 146, 29, 18, 205, 145, 240, 106, 183, 33, 91, 189, 133, 75, 32, 222, 251, 21, 85, 151, 160, 13, 92, 255, 209, 35, 44, 1, 184, 117, 95, 61, 202, 184, 41, 183, 65, 205, 182, 72, 14, 230, 240, 63, 24, 37, 26, 34, 172, 3, 44, 72, 87, 39, 90, 117, 140, 155, 248, 60, 34, 234, 116, 46, 227, 36, 247, 86, 2, 86, 226, 123, 157, 76, 200, 21, 56, 255, 158, 253, 200, 88, 243, 227, 43, 35, 60, 24, 48, 146, 12, 45, 83, 212, 136, 57, 45, 1, 6, 219, 165, 148, 153, 245, 84, 91, 243, 202, 13, 206, 112, 171, 89, 6, 144, 158, 34, 161, 189, 161, 30 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "DishTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 84, 98, 245, 156, 75, 67, 191, 36, 125, 34, 126, 185, 24, 214, 112, 191, 248, 149, 39, 35, 164, 6, 192, 47, 243, 2, 46, 177, 234, 26, 228, 201, 175, 63, 206, 52, 55, 243, 230, 102, 203, 196, 131, 6, 57, 215, 204, 224, 111, 247, 112, 91, 16, 132, 21, 226, 144, 5, 74, 156, 211, 93, 67 }, new byte[] { 84, 106, 208, 208, 205, 130, 233, 13, 102, 198, 35, 191, 216, 241, 105, 32, 149, 118, 36, 106, 136, 62, 42, 100, 5, 174, 76, 12, 240, 121, 118, 105, 242, 36, 248, 170, 170, 207, 98, 94, 241, 25, 135, 80, 64, 52, 86, 55, 80, 105, 173, 72, 4, 148, 253, 90, 65, 126, 51, 23, 10, 89, 2, 37, 157, 6, 3, 79, 247, 177, 216, 181, 83, 153, 57, 164, 221, 128, 25, 73, 97, 247, 162, 98, 4, 219, 161, 128, 206, 70, 230, 229, 182, 14, 240, 106, 21, 155, 128, 93, 70, 104, 79, 208, 239, 68, 244, 124, 206, 118, 96, 7, 65, 191, 161, 247, 209, 240, 40, 201, 143, 144, 198, 24, 177, 38, 86, 71 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 84, 98, 245, 156, 75, 67, 191, 36, 125, 34, 126, 185, 24, 214, 112, 191, 248, 149, 39, 35, 164, 6, 192, 47, 243, 2, 46, 177, 234, 26, 228, 201, 175, 63, 206, 52, 55, 243, 230, 102, 203, 196, 131, 6, 57, 215, 204, 224, 111, 247, 112, 91, 16, 132, 21, 226, 144, 5, 74, 156, 211, 93, 67 }, new byte[] { 84, 106, 208, 208, 205, 130, 233, 13, 102, 198, 35, 191, 216, 241, 105, 32, 149, 118, 36, 106, 136, 62, 42, 100, 5, 174, 76, 12, 240, 121, 118, 105, 242, 36, 248, 170, 170, 207, 98, 94, 241, 25, 135, 80, 64, 52, 86, 55, 80, 105, 173, 72, 4, 148, 253, 90, 65, 126, 51, 23, 10, 89, 2, 37, 157, 6, 3, 79, 247, 177, 216, 181, 83, 153, 57, 164, 221, 128, 25, 73, 97, 247, 162, 98, 4, 219, 161, 128, 206, 70, 230, 229, 182, 14, 240, 106, 21, 155, 128, 93, 70, 104, 79, 208, 239, 68, 244, 124, 206, 118, 96, 7, 65, 191, 161, 247, 209, 240, 40, 201, 143, 144, 198, 24, 177, 38, 86, 71 } });
        }
    }
}
