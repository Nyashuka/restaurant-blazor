using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class MoveCategoryIntoFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_DrinkCategories_DrinkCategoryId",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_DrinkCategoryId",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DrinkCategoryId",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "DishCategoryId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FoodItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 136, 25, 183, 21, 13, 94, 184, 95, 63, 8, 59, 41, 107, 93, 15, 203, 173, 112, 15, 188, 84, 49, 140, 242, 128, 153, 114, 59, 15, 91, 165, 200, 5, 94, 207, 108, 186, 215, 13, 34, 20, 118, 10, 58, 183, 196, 147, 197, 44, 52, 64, 128, 24, 1, 51, 93, 199, 201, 85, 15, 223, 124, 175 }, new byte[] { 9, 218, 127, 108, 77, 144, 219, 88, 112, 20, 192, 92, 21, 177, 229, 143, 193, 29, 171, 12, 71, 103, 108, 122, 190, 185, 201, 198, 204, 99, 252, 112, 104, 164, 232, 228, 133, 102, 94, 89, 57, 24, 189, 46, 86, 254, 126, 135, 160, 177, 247, 206, 148, 97, 195, 235, 41, 45, 255, 5, 160, 99, 187, 174, 167, 152, 53, 254, 91, 220, 206, 10, 104, 34, 182, 89, 2, 161, 75, 196, 62, 239, 89, 225, 44, 230, 201, 237, 180, 5, 161, 18, 145, 221, 42, 3, 149, 35, 61, 161, 39, 101, 250, 43, 247, 132, 192, 250, 72, 183, 198, 46, 57, 79, 93, 82, 195, 86, 222, 129, 118, 16, 189, 29, 8, 178, 47, 117 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 220, 136, 25, 183, 21, 13, 94, 184, 95, 63, 8, 59, 41, 107, 93, 15, 203, 173, 112, 15, 188, 84, 49, 140, 242, 128, 153, 114, 59, 15, 91, 165, 200, 5, 94, 207, 108, 186, 215, 13, 34, 20, 118, 10, 58, 183, 196, 147, 197, 44, 52, 64, 128, 24, 1, 51, 93, 199, 201, 85, 15, 223, 124, 175 }, new byte[] { 9, 218, 127, 108, 77, 144, 219, 88, 112, 20, 192, 92, 21, 177, 229, 143, 193, 29, 171, 12, 71, 103, 108, 122, 190, 185, 201, 198, 204, 99, 252, 112, 104, 164, 232, 228, 133, 102, 94, 89, 57, 24, 189, 46, 86, 254, 126, 135, 160, 177, 247, 206, 148, 97, 195, 235, 41, 45, 255, 5, 160, 99, 187, 174, 167, 152, 53, 254, 91, 220, 206, 10, 104, 34, 182, 89, 2, 161, 75, 196, 62, 239, 89, 225, 44, 230, 201, 237, 180, 5, 161, 18, 145, 221, 42, 3, 149, 35, 61, 161, 39, 101, 250, 43, 247, 132, 192, 250, 72, 183, 198, 46, 57, 79, 93, 82, 195, 86, 222, 129, 118, 16, 189, 29, 8, 178, 47, 117 } });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CategoryId",
                table: "FoodItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_CategoryBase_CategoryId",
                table: "FoodItems",
                column: "CategoryId",
                principalTable: "CategoryBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_CategoryBase_CategoryId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_CategoryId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoodItems");

            migrationBuilder.AddColumn<int>(
                name: "DrinkCategoryId",
                table: "Drinks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DishCategoryId",
                table: "Dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinkCategoryId",
                table: "Drinks",
                column: "DrinkCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishCategories_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId",
                principalTable: "DishCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_DrinkCategories_DrinkCategoryId",
                table: "Drinks",
                column: "DrinkCategoryId",
                principalTable: "DrinkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
