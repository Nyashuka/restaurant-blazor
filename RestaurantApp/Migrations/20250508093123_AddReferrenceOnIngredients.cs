﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddReferrenceOnIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 125, 206, 98, 54, 179, 230, 45, 73, 104, 143, 112, 142, 230, 123, 88, 112, 26, 101, 63, 42, 104, 122, 17, 104, 40, 213, 116, 195, 153, 20, 99, 45, 88, 239, 206, 135, 111, 170, 97, 57, 28, 3, 228, 75, 103, 132, 201, 166, 128, 156, 196, 215, 87, 145, 149, 90, 151, 168, 18, 126, 125, 243, 220, 26 }, new byte[] { 120, 152, 87, 206, 223, 121, 95, 106, 99, 44, 62, 116, 224, 128, 3, 118, 245, 103, 29, 29, 66, 115, 168, 175, 230, 79, 218, 82, 131, 216, 188, 56, 109, 199, 215, 254, 203, 167, 38, 254, 193, 165, 115, 53, 5, 190, 42, 201, 39, 108, 149, 137, 113, 167, 61, 60, 234, 150, 62, 234, 109, 219, 164, 135, 185, 216, 225, 81, 209, 64, 191, 164, 54, 160, 135, 124, 30, 11, 169, 230, 227, 82, 30, 172, 226, 0, 179, 44, 147, 176, 131, 240, 232, 200, 230, 106, 194, 181, 112, 49, 5, 238, 176, 60, 236, 67, 83, 41, 166, 249, 247, 153, 227, 246, 233, 38, 111, 146, 107, 69, 210, 233, 10, 185, 199, 158, 42, 183 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 125, 206, 98, 54, 179, 230, 45, 73, 104, 143, 112, 142, 230, 123, 88, 112, 26, 101, 63, 42, 104, 122, 17, 104, 40, 213, 116, 195, 153, 20, 99, 45, 88, 239, 206, 135, 111, 170, 97, 57, 28, 3, 228, 75, 103, 132, 201, 166, 128, 156, 196, 215, 87, 145, 149, 90, 151, 168, 18, 126, 125, 243, 220, 26 }, new byte[] { 120, 152, 87, 206, 223, 121, 95, 106, 99, 44, 62, 116, 224, 128, 3, 118, 245, 103, 29, 29, 66, 115, 168, 175, 230, 79, 218, 82, 131, 216, 188, 56, 109, 199, 215, 254, 203, 167, 38, 254, 193, 165, 115, 53, 5, 190, 42, 201, 39, 108, 149, 137, 113, 167, 61, 60, 234, 150, 62, 234, 109, 219, 164, 135, 185, 216, 225, 81, 209, 64, 191, 164, 54, 160, 135, 124, 30, 11, 169, 230, 227, 82, 30, 172, 226, 0, 179, 44, 147, 176, 131, 240, 232, 200, 230, 106, 194, 181, 112, 49, 5, 238, 176, 60, 236, 67, 83, 41, 166, 249, 247, 153, 227, 246, 233, 38, 111, 146, 107, 69, 210, 233, 10, 185, 199, 158, 42, 183 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 105, 145, 102, 167, 126, 63, 93, 81, 33, 60, 169, 93, 167, 116, 181, 115, 253, 199, 246, 76, 28, 169, 154, 117, 197, 62, 0, 222, 27, 13, 244, 193, 122, 70, 140, 172, 79, 177, 159, 179, 186, 249, 41, 172, 92, 73, 55, 249, 108, 125, 6, 249, 128, 74, 213, 216, 13, 24, 253, 148, 235, 214, 94 }, new byte[] { 231, 204, 201, 22, 242, 191, 82, 174, 244, 34, 78, 248, 167, 64, 205, 70, 21, 28, 20, 211, 137, 176, 22, 209, 209, 37, 210, 0, 112, 187, 228, 72, 199, 5, 4, 154, 251, 233, 90, 200, 184, 76, 45, 136, 209, 27, 249, 222, 33, 80, 38, 49, 205, 122, 161, 235, 36, 104, 127, 234, 173, 205, 189, 35, 235, 148, 170, 196, 65, 196, 140, 61, 54, 47, 13, 15, 164, 128, 118, 91, 151, 73, 101, 168, 244, 114, 202, 205, 173, 33, 17, 88, 135, 230, 237, 30, 135, 218, 140, 30, 230, 140, 11, 220, 41, 188, 45, 51, 126, 228, 240, 29, 55, 99, 172, 254, 191, 12, 62, 0, 137, 90, 155, 211, 119, 197, 214, 8 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 105, 145, 102, 167, 126, 63, 93, 81, 33, 60, 169, 93, 167, 116, 181, 115, 253, 199, 246, 76, 28, 169, 154, 117, 197, 62, 0, 222, 27, 13, 244, 193, 122, 70, 140, 172, 79, 177, 159, 179, 186, 249, 41, 172, 92, 73, 55, 249, 108, 125, 6, 249, 128, 74, 213, 216, 13, 24, 253, 148, 235, 214, 94 }, new byte[] { 231, 204, 201, 22, 242, 191, 82, 174, 244, 34, 78, 248, 167, 64, 205, 70, 21, 28, 20, 211, 137, 176, 22, 209, 209, 37, 210, 0, 112, 187, 228, 72, 199, 5, 4, 154, 251, 233, 90, 200, 184, 76, 45, 136, 209, 27, 249, 222, 33, 80, 38, 49, 205, 122, 161, 235, 36, 104, 127, 234, 173, 205, 189, 35, 235, 148, 170, 196, 65, 196, 140, 61, 54, 47, 13, 15, 164, 128, 118, 91, 151, 73, 101, 168, 244, 114, 202, 205, 173, 33, 17, 88, 135, 230, 237, 30, 135, 218, 140, 30, 230, 140, 11, 220, 41, 188, 45, 51, 126, 228, 240, 29, 55, 99, 172, 254, 191, 12, 62, 0, 137, 90, 155, 211, 119, 197, 214, 8 } });
        }
    }
}
