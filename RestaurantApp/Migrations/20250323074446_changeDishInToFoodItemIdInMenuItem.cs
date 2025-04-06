using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class changeDishInToFoodItemIdInMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Dishes_DishId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "MenuItems",
                newName: "FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_DishId",
                table: "MenuItems",
                newName: "IX_MenuItems_FoodItemId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 36, 156, 56, 179, 129, 61, 97, 20, 168, 46, 159, 195, 192, 133, 165, 143, 95, 137, 128, 103, 28, 223, 237, 21, 111, 226, 65, 189, 123, 175, 120, 173, 10, 252, 51, 57, 1, 106, 154, 46, 132, 130, 164, 10, 210, 180, 200, 183, 38, 36, 251, 211, 224, 168, 127, 140, 29, 236, 169, 244, 124, 147, 209 }, new byte[] { 10, 172, 150, 213, 199, 14, 55, 9, 165, 167, 41, 251, 234, 34, 244, 244, 237, 8, 8, 141, 22, 89, 63, 111, 161, 175, 95, 30, 251, 189, 247, 156, 183, 115, 199, 212, 58, 139, 209, 9, 79, 213, 93, 47, 190, 92, 224, 96, 166, 111, 29, 73, 87, 79, 193, 159, 78, 244, 141, 90, 157, 130, 232, 22, 161, 85, 108, 161, 156, 24, 89, 212, 220, 213, 217, 242, 183, 200, 19, 151, 98, 248, 58, 79, 246, 92, 62, 203, 9, 18, 217, 186, 165, 100, 200, 58, 104, 176, 193, 214, 27, 165, 94, 164, 250, 24, 248, 146, 189, 104, 189, 3, 165, 249, 35, 179, 167, 135, 190, 245, 23, 51, 196, 203, 123, 102, 103, 236 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 36, 156, 56, 179, 129, 61, 97, 20, 168, 46, 159, 195, 192, 133, 165, 143, 95, 137, 128, 103, 28, 223, 237, 21, 111, 226, 65, 189, 123, 175, 120, 173, 10, 252, 51, 57, 1, 106, 154, 46, 132, 130, 164, 10, 210, 180, 200, 183, 38, 36, 251, 211, 224, 168, 127, 140, 29, 236, 169, 244, 124, 147, 209 }, new byte[] { 10, 172, 150, 213, 199, 14, 55, 9, 165, 167, 41, 251, 234, 34, 244, 244, 237, 8, 8, 141, 22, 89, 63, 111, 161, 175, 95, 30, 251, 189, 247, 156, 183, 115, 199, 212, 58, 139, 209, 9, 79, 213, 93, 47, 190, 92, 224, 96, 166, 111, 29, 73, 87, 79, 193, 159, 78, 244, 141, 90, 157, 130, 232, 22, 161, 85, 108, 161, 156, 24, 89, 212, 220, 213, 217, 242, 183, 200, 19, 151, 98, 248, 58, 79, 246, 92, 62, 203, 9, 18, 217, 186, 165, 100, 200, 58, 104, 176, 193, 214, 27, 165, 94, 164, 250, 24, 248, 146, 189, 104, 189, 3, 165, 249, 35, 179, 167, 135, 190, 245, 23, 51, 196, 203, 123, 102, 103, 236 } });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_FoodItems_FoodItemId",
                table: "MenuItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_FoodItems_FoodItemId",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "MenuItems",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_FoodItemId",
                table: "MenuItems",
                newName: "IX_MenuItems_DishId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 78, 135, 205, 65, 128, 228, 25, 125, 171, 154, 240, 32, 48, 76, 173, 25, 233, 232, 52, 161, 147, 184, 3, 232, 198, 181, 82, 150, 201, 165, 158, 220, 82, 234, 208, 218, 111, 0, 195, 3, 251, 43, 64, 41, 22, 137, 236, 187, 169, 19, 14, 222, 156, 92, 137, 251, 126, 34, 209, 64, 254, 223, 126 }, new byte[] { 212, 50, 7, 204, 204, 120, 21, 194, 146, 91, 39, 149, 212, 73, 214, 107, 188, 228, 174, 243, 255, 101, 126, 88, 140, 6, 182, 179, 166, 244, 127, 30, 66, 102, 185, 164, 225, 159, 167, 20, 137, 199, 90, 7, 212, 103, 238, 174, 116, 28, 147, 39, 117, 96, 130, 71, 216, 254, 132, 224, 187, 40, 115, 199, 117, 251, 65, 82, 148, 43, 61, 117, 98, 157, 79, 228, 48, 152, 51, 46, 141, 203, 188, 182, 68, 71, 134, 143, 82, 68, 75, 135, 142, 25, 62, 83, 81, 86, 111, 139, 74, 185, 37, 209, 171, 219, 173, 199, 72, 181, 153, 31, 145, 225, 232, 17, 26, 60, 80, 6, 204, 63, 209, 247, 141, 53, 253, 160 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 78, 135, 205, 65, 128, 228, 25, 125, 171, 154, 240, 32, 48, 76, 173, 25, 233, 232, 52, 161, 147, 184, 3, 232, 198, 181, 82, 150, 201, 165, 158, 220, 82, 234, 208, 218, 111, 0, 195, 3, 251, 43, 64, 41, 22, 137, 236, 187, 169, 19, 14, 222, 156, 92, 137, 251, 126, 34, 209, 64, 254, 223, 126 }, new byte[] { 212, 50, 7, 204, 204, 120, 21, 194, 146, 91, 39, 149, 212, 73, 214, 107, 188, 228, 174, 243, 255, 101, 126, 88, 140, 6, 182, 179, 166, 244, 127, 30, 66, 102, 185, 164, 225, 159, 167, 20, 137, 199, 90, 7, 212, 103, 238, 174, 116, 28, 147, 39, 117, 96, 130, 71, 216, 254, 132, 224, 187, 40, 115, 199, 117, 251, 65, 82, 148, 43, 61, 117, 98, 157, 79, 228, 48, 152, 51, 46, 141, 203, 188, 182, 68, 71, 134, 143, 82, 68, 75, 135, 142, 25, 62, 83, 81, 86, 111, 139, 74, 185, 37, 209, 171, 219, 173, 199, 72, 181, 153, 31, 145, 225, 232, 17, 26, 60, 80, 6, 204, 63, 209, 247, 141, 53, 253, 160 } });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Dishes_DishId",
                table: "MenuItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
