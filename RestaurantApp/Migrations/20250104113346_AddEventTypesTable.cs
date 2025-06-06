﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEventTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 206, 134, 111, 77, 208, 38, 8, 159, 160, 127, 83, 231, 221, 155, 77, 54, 39, 21, 184, 162, 99, 217, 149, 121, 155, 62, 200, 237, 101, 238, 164, 126, 120, 1, 129, 45, 155, 141, 86, 61, 195, 250, 54, 229, 21, 205, 71, 3, 160, 5, 45, 155, 230, 166, 188, 231, 47, 62, 252, 57, 252, 223, 36 }, new byte[] { 153, 226, 207, 192, 222, 73, 183, 184, 120, 135, 191, 211, 139, 63, 159, 187, 138, 37, 6, 181, 155, 157, 164, 211, 234, 130, 160, 254, 184, 172, 168, 41, 181, 14, 28, 166, 119, 138, 27, 8, 123, 41, 250, 74, 225, 137, 79, 136, 149, 248, 246, 171, 5, 69, 29, 125, 131, 110, 126, 75, 123, 163, 184, 92, 169, 86, 33, 96, 126, 96, 23, 207, 193, 252, 183, 46, 241, 60, 245, 115, 189, 121, 162, 179, 20, 102, 200, 206, 82, 217, 105, 18, 45, 79, 121, 202, 226, 123, 69, 195, 20, 67, 11, 42, 66, 177, 136, 61, 211, 78, 134, 15, 116, 43, 51, 82, 78, 108, 208, 207, 47, 220, 113, 71, 29, 229, 236, 123 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 206, 134, 111, 77, 208, 38, 8, 159, 160, 127, 83, 231, 221, 155, 77, 54, 39, 21, 184, 162, 99, 217, 149, 121, 155, 62, 200, 237, 101, 238, 164, 126, 120, 1, 129, 45, 155, 141, 86, 61, 195, 250, 54, 229, 21, 205, 71, 3, 160, 5, 45, 155, 230, 166, 188, 231, 47, 62, 252, 57, 252, 223, 36 }, new byte[] { 153, 226, 207, 192, 222, 73, 183, 184, 120, 135, 191, 211, 139, 63, 159, 187, 138, 37, 6, 181, 155, 157, 164, 211, 234, 130, 160, 254, 184, 172, 168, 41, 181, 14, 28, 166, 119, 138, 27, 8, 123, 41, 250, 74, 225, 137, 79, 136, 149, 248, 246, 171, 5, 69, 29, 125, 131, 110, 126, 75, 123, 163, 184, 92, 169, 86, 33, 96, 126, 96, 23, 207, 193, 252, 183, 46, 241, 60, 245, 115, 189, 121, 162, 179, 20, 102, 200, 206, 82, 217, 105, 18, 45, 79, 121, 202, 226, 123, 69, 195, 20, 67, 11, 42, 66, 177, 136, 61, 211, 78, 134, 15, 116, 43, 51, 82, 78, 108, 208, 207, 47, 220, 113, 71, 29, 229, 236, 123 } });
        }
    }
}
