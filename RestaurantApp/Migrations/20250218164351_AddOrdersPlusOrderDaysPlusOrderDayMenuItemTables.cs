using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersPlusOrderDaysPlusOrderDayMenuItemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DishTypes");

            migrationBuilder.RenameColumn(
                name: "DishTypeId",
                table: "Dishes",
                newName: "DishCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DishTypeId",
                table: "Dishes",
                newName: "IX_Dishes_DishCategoryId");

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsShared = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PeopleCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDays_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDayId = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_OrderDays_OrderDayId",
                        column: x => x.OrderDayId,
                        principalTable: "OrderDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 156, 19, 170, 113, 243, 21, 125, 105, 109, 151, 101, 163, 208, 168, 229, 185, 12, 124, 146, 123, 105, 99, 154, 111, 102, 237, 118, 25, 108, 247, 208, 180, 220, 159, 55, 137, 25, 25, 167, 233, 8, 253, 187, 24, 48, 173, 52, 151, 146, 207, 148, 150, 66, 184, 197, 194, 214, 170, 13, 99, 162, 23, 93 }, new byte[] { 73, 127, 61, 107, 100, 170, 205, 194, 132, 150, 214, 161, 177, 13, 86, 67, 113, 115, 237, 159, 166, 31, 170, 156, 61, 154, 53, 139, 33, 200, 10, 110, 27, 46, 60, 245, 67, 248, 21, 45, 186, 114, 201, 96, 41, 204, 121, 95, 128, 13, 143, 53, 56, 162, 55, 49, 213, 93, 228, 136, 174, 67, 241, 199, 23, 211, 198, 6, 26, 19, 44, 160, 19, 64, 133, 152, 111, 57, 153, 223, 73, 149, 207, 210, 231, 85, 87, 203, 227, 254, 152, 221, 208, 138, 218, 174, 64, 129, 6, 241, 235, 243, 217, 195, 171, 81, 206, 154, 152, 175, 103, 138, 31, 77, 35, 90, 214, 79, 105, 84, 70, 232, 160, 237, 108, 91, 243, 234 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 98, 156, 19, 170, 113, 243, 21, 125, 105, 109, 151, 101, 163, 208, 168, 229, 185, 12, 124, 146, 123, 105, 99, 154, 111, 102, 237, 118, 25, 108, 247, 208, 180, 220, 159, 55, 137, 25, 25, 167, 233, 8, 253, 187, 24, 48, 173, 52, 151, 146, 207, 148, 150, 66, 184, 197, 194, 214, 170, 13, 99, 162, 23, 93 }, new byte[] { 73, 127, 61, 107, 100, 170, 205, 194, 132, 150, 214, 161, 177, 13, 86, 67, 113, 115, 237, 159, 166, 31, 170, 156, 61, 154, 53, 139, 33, 200, 10, 110, 27, 46, 60, 245, 67, 248, 21, 45, 186, 114, 201, 96, 41, 204, 121, 95, 128, 13, 143, 53, 56, 162, 55, 49, 213, 93, 228, 136, 174, 67, 241, 199, 23, 211, 198, 6, 26, 19, 44, 160, 19, 64, 133, 152, 111, 57, 153, 223, 73, 149, 207, 210, 231, 85, 87, 203, 227, 254, 152, 221, 208, 138, 218, 174, 64, 129, 6, 241, 235, 243, 217, 195, 171, 81, 206, 154, 152, 175, 103, 138, 31, 77, 35, 90, 214, 79, 105, 84, 70, 232, 160, 237, 108, 91, 243, 234 } });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDays_OrderId",
                table: "OrderDays",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_DishId",
                table: "OrderMenuItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_OrderDayId",
                table: "OrderMenuItems",
                column: "OrderDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId",
                principalTable: "DishCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropTable(
                name: "OrderMenuItems");

            migrationBuilder.DropTable(
                name: "OrderDays");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "DishCategoryId",
                table: "Dishes",
                newName: "DishTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes",
                newName: "IX_Dishes_DishTypeId");

            migrationBuilder.CreateTable(
                name: "DishTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsShared = table.Column<bool>(type: "boolean", nullable: false),
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
                values: new object[] { new byte[] { 133, 202, 124, 7, 15, 170, 201, 143, 108, 37, 119, 110, 245, 74, 116, 50, 153, 103, 174, 242, 167, 171, 224, 111, 82, 75, 198, 45, 221, 44, 21, 59, 185, 173, 147, 167, 140, 77, 198, 128, 78, 236, 211, 222, 76, 120, 164, 220, 34, 56, 216, 177, 36, 132, 68, 17, 178, 53, 168, 134, 67, 167, 156, 173 }, new byte[] { 49, 5, 138, 154, 133, 84, 3, 33, 118, 149, 90, 63, 151, 221, 90, 118, 58, 145, 206, 32, 3, 232, 190, 111, 174, 57, 248, 128, 41, 135, 235, 181, 122, 230, 244, 56, 30, 98, 205, 158, 233, 11, 39, 224, 50, 32, 72, 108, 97, 127, 175, 200, 195, 34, 217, 161, 167, 149, 223, 80, 65, 138, 90, 242, 233, 189, 229, 204, 215, 119, 146, 123, 56, 2, 108, 184, 224, 105, 97, 113, 209, 114, 84, 171, 1, 211, 201, 116, 130, 182, 64, 218, 235, 223, 139, 121, 99, 22, 115, 242, 89, 50, 74, 97, 54, 24, 233, 254, 59, 214, 176, 4, 110, 179, 209, 87, 177, 37, 122, 69, 11, 14, 193, 228, 92, 41, 181, 63 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 133, 202, 124, 7, 15, 170, 201, 143, 108, 37, 119, 110, 245, 74, 116, 50, 153, 103, 174, 242, 167, 171, 224, 111, 82, 75, 198, 45, 221, 44, 21, 59, 185, 173, 147, 167, 140, 77, 198, 128, 78, 236, 211, 222, 76, 120, 164, 220, 34, 56, 216, 177, 36, 132, 68, 17, 178, 53, 168, 134, 67, 167, 156, 173 }, new byte[] { 49, 5, 138, 154, 133, 84, 3, 33, 118, 149, 90, 63, 151, 221, 90, 118, 58, 145, 206, 32, 3, 232, 190, 111, 174, 57, 248, 128, 41, 135, 235, 181, 122, 230, 244, 56, 30, 98, 205, 158, 233, 11, 39, 224, 50, 32, 72, 108, 97, 127, 175, 200, 195, 34, 217, 161, 167, 149, 223, 80, 65, 138, 90, 242, 233, 189, 229, 204, 215, 119, 146, 123, 56, 2, 108, 184, 224, 105, 97, 113, 209, 114, 84, 171, 1, 211, 201, 116, 130, 182, 64, 218, 235, 223, 139, 121, 99, 22, 115, 242, 89, 50, 74, 97, 54, 24, 233, 254, 59, 214, 176, 4, 110, 179, 209, 87, 177, 37, 122, 69, 11, 14, 193, 228, 92, 41, 181, 63 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishTypes_DishTypeId",
                table: "Dishes",
                column: "DishTypeId",
                principalTable: "DishTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
