using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuAndMenuItemsTablesWithConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EventTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    MenuId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId1",
                        column: x => x.MenuId1,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_DishId",
                table: "MenuItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId1",
                table: "MenuItems",
                column: "MenuId1");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_EventTypeId",
                table: "Menus",
                column: "EventTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 196, 93, 76, 133, 194, 112, 182, 240, 238, 123, 160, 250, 29, 33, 150, 189, 91, 129, 58, 28, 2, 227, 30, 232, 97, 140, 93, 149, 159, 173, 152, 182, 30, 166, 22, 160, 46, 11, 3, 107, 161, 4, 158, 213, 59, 138, 244, 221, 123, 55, 167, 109, 219, 161, 71, 73, 189, 194, 94, 156, 52, 7, 161 }, new byte[] { 47, 240, 232, 117, 186, 206, 245, 163, 46, 42, 215, 42, 233, 205, 124, 59, 194, 31, 249, 136, 11, 242, 67, 88, 176, 183, 153, 169, 181, 246, 172, 30, 156, 247, 195, 115, 101, 78, 185, 203, 239, 77, 48, 221, 224, 98, 93, 183, 188, 47, 33, 100, 104, 134, 55, 111, 111, 182, 110, 226, 40, 138, 92, 156, 168, 99, 173, 154, 108, 71, 118, 210, 242, 229, 80, 96, 228, 169, 201, 129, 145, 6, 211, 150, 36, 226, 180, 56, 83, 113, 227, 74, 250, 85, 131, 113, 20, 236, 214, 166, 241, 212, 56, 230, 129, 57, 190, 83, 141, 86, 204, 37, 69, 0, 91, 215, 146, 247, 214, 145, 118, 50, 49, 78, 41, 75, 165, 186 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 196, 93, 76, 133, 194, 112, 182, 240, 238, 123, 160, 250, 29, 33, 150, 189, 91, 129, 58, 28, 2, 227, 30, 232, 97, 140, 93, 149, 159, 173, 152, 182, 30, 166, 22, 160, 46, 11, 3, 107, 161, 4, 158, 213, 59, 138, 244, 221, 123, 55, 167, 109, 219, 161, 71, 73, 189, 194, 94, 156, 52, 7, 161 }, new byte[] { 47, 240, 232, 117, 186, 206, 245, 163, 46, 42, 215, 42, 233, 205, 124, 59, 194, 31, 249, 136, 11, 242, 67, 88, 176, 183, 153, 169, 181, 246, 172, 30, 156, 247, 195, 115, 101, 78, 185, 203, 239, 77, 48, 221, 224, 98, 93, 183, 188, 47, 33, 100, 104, 134, 55, 111, 111, 182, 110, 226, 40, 138, 92, 156, 168, 99, 173, 154, 108, 71, 118, 210, 242, 229, 80, 96, 228, 169, 201, 129, 145, 6, 211, 150, 36, 226, 180, 56, 83, 113, 227, 74, 250, 85, 131, 113, 20, 236, 214, 166, 241, 212, 56, 230, 129, 57, 190, 83, 141, 86, 204, 37, 69, 0, 91, 215, 146, 247, 214, 145, 118, 50, 49, 78, 41, 75, 165, 186 } });
        }
    }
}
