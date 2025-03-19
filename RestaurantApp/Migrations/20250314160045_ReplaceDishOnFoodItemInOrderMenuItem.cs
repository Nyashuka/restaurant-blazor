using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceDishOnFoodItemInOrderMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItems_Dishes_DishId",
                table: "OrderMenuItems");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "OrderMenuItems",
                newName: "FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItems_DishId",
                table: "OrderMenuItems",
                newName: "IX_OrderMenuItems_FoodItemId");

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
                name: "FK_OrderMenuItems_FoodItems_FoodItemId",
                table: "OrderMenuItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenuItems_FoodItems_FoodItemId",
                table: "OrderMenuItems");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "OrderMenuItems",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenuItems_FoodItemId",
                table: "OrderMenuItems",
                newName: "IX_OrderMenuItems_DishId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 108, 74, 46, 222, 251, 152, 171, 184, 130, 10, 79, 81, 120, 68, 75, 2, 190, 96, 141, 106, 22, 243, 29, 108, 35, 94, 165, 153, 89, 165, 224, 104, 145, 67, 67, 168, 91, 226, 17, 213, 150, 79, 193, 236, 164, 11, 155, 224, 224, 180, 76, 66, 23, 19, 202, 9, 25, 202, 82, 159, 135, 83, 85 }, new byte[] { 144, 96, 117, 161, 241, 71, 84, 207, 1, 178, 158, 243, 59, 52, 112, 56, 223, 91, 139, 223, 107, 24, 153, 152, 77, 85, 160, 114, 160, 2, 9, 106, 185, 219, 172, 237, 99, 226, 195, 230, 61, 123, 152, 206, 111, 163, 123, 1, 53, 182, 217, 192, 245, 38, 97, 178, 235, 185, 245, 8, 61, 197, 167, 176, 115, 11, 87, 174, 6, 84, 28, 220, 216, 1, 80, 94, 187, 197, 116, 177, 230, 15, 183, 162, 178, 158, 159, 250, 40, 30, 236, 188, 195, 35, 33, 153, 61, 194, 149, 215, 242, 196, 177, 170, 73, 252, 138, 221, 179, 31, 143, 171, 199, 80, 73, 166, 192, 156, 145, 195, 199, 183, 144, 87, 48, 241, 251, 6 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 219, 108, 74, 46, 222, 251, 152, 171, 184, 130, 10, 79, 81, 120, 68, 75, 2, 190, 96, 141, 106, 22, 243, 29, 108, 35, 94, 165, 153, 89, 165, 224, 104, 145, 67, 67, 168, 91, 226, 17, 213, 150, 79, 193, 236, 164, 11, 155, 224, 224, 180, 76, 66, 23, 19, 202, 9, 25, 202, 82, 159, 135, 83, 85 }, new byte[] { 144, 96, 117, 161, 241, 71, 84, 207, 1, 178, 158, 243, 59, 52, 112, 56, 223, 91, 139, 223, 107, 24, 153, 152, 77, 85, 160, 114, 160, 2, 9, 106, 185, 219, 172, 237, 99, 226, 195, 230, 61, 123, 152, 206, 111, 163, 123, 1, 53, 182, 217, 192, 245, 38, 97, 178, 235, 185, 245, 8, 61, 197, 167, 176, 115, 11, 87, 174, 6, 84, 28, 220, 216, 1, 80, 94, 187, 197, 116, 177, 230, 15, 183, 162, 178, 158, 159, 250, 40, 30, 236, 188, 195, 35, 33, 153, 61, 194, 149, 215, 242, 196, 177, 170, 73, 252, 138, 221, 179, 31, 143, 171, 199, 80, 73, 166, 192, 156, 145, 195, 199, 183, 144, 87, 48, 241, 251, 6 } });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenuItems_Dishes_DishId",
                table: "OrderMenuItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
