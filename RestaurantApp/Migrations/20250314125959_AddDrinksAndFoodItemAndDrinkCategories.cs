using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDrinksAndFoodItemAndDrinkCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "PricePerUnit",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "DishCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DishCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DishCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "CategoryBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsShared = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PricePerUnit = table.Column<double>(type: "double precision", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkCategories_CategoryBase_Id",
                        column: x => x.Id,
                        principalTable: "CategoryBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DrinkCategoryId = table.Column<int>(type: "integer", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    VolumePerPerson = table.Column<int>(type: "integer", nullable: false),
                    IsAlcoholic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_DrinkCategories_DrinkCategoryId",
                        column: x => x.DrinkCategoryId,
                        principalTable: "DrinkCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_FoodItems_Id",
                        column: x => x.Id,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinkCategoryId",
                table: "Drinks",
                column: "DrinkCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishCategories_CategoryBase_Id",
                table: "DishCategories",
                column: "Id",
                principalTable: "CategoryBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_FoodItems_Id",
                table: "Dishes",
                column: "Id",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishCategories_CategoryBase_Id",
                table: "DishCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_FoodItems_Id",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "DrinkCategories");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "CategoryBase");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dishes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PricePerUnit",
                table: "Dishes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DishCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "DishCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DishCategories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 186, 109, 61, 30, 170, 170, 106, 88, 48, 37, 2, 62, 100, 21, 239, 161, 114, 203, 95, 113, 86, 62, 252, 177, 102, 61, 141, 144, 126, 130, 237, 183, 15, 210, 20, 9, 179, 248, 179, 29, 250, 10, 125, 247, 161, 224, 91, 195, 73, 81, 79, 203, 61, 219, 28, 235, 144, 164, 189, 54, 39, 231, 113, 34 }, new byte[] { 121, 236, 88, 115, 203, 224, 206, 80, 236, 191, 8, 14, 241, 156, 98, 17, 189, 209, 163, 83, 119, 82, 49, 136, 84, 111, 218, 109, 116, 10, 15, 25, 180, 161, 238, 178, 173, 130, 196, 128, 249, 105, 174, 65, 255, 248, 115, 58, 87, 108, 90, 54, 37, 105, 146, 212, 197, 165, 97, 74, 201, 228, 202, 211, 52, 130, 103, 81, 183, 190, 141, 109, 50, 205, 165, 103, 200, 135, 198, 7, 110, 29, 35, 1, 188, 2, 6, 8, 170, 75, 29, 57, 210, 54, 239, 146, 182, 168, 193, 20, 243, 153, 84, 0, 84, 22, 219, 213, 5, 102, 174, 245, 121, 54, 234, 2, 78, 3, 45, 164, 184, 155, 157, 4, 35, 154, 80, 115 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 186, 109, 61, 30, 170, 170, 106, 88, 48, 37, 2, 62, 100, 21, 239, 161, 114, 203, 95, 113, 86, 62, 252, 177, 102, 61, 141, 144, 126, 130, 237, 183, 15, 210, 20, 9, 179, 248, 179, 29, 250, 10, 125, 247, 161, 224, 91, 195, 73, 81, 79, 203, 61, 219, 28, 235, 144, 164, 189, 54, 39, 231, 113, 34 }, new byte[] { 121, 236, 88, 115, 203, 224, 206, 80, 236, 191, 8, 14, 241, 156, 98, 17, 189, 209, 163, 83, 119, 82, 49, 136, 84, 111, 218, 109, 116, 10, 15, 25, 180, 161, 238, 178, 173, 130, 196, 128, 249, 105, 174, 65, 255, 248, 115, 58, 87, 108, 90, 54, 37, 105, 146, 212, 197, 165, 97, 74, 201, 228, 202, 211, 52, 130, 103, 81, 183, 190, 141, 109, 50, 205, 165, 103, 200, 135, 198, 7, 110, 29, 35, 1, 188, 2, 6, 8, 170, 75, 29, 57, 210, 54, 239, 146, 182, 168, 193, 20, 243, 153, 84, 0, 84, 22, 219, 213, 5, 102, 174, 245, 121, 54, 234, 2, 78, 3, 45, 164, 184, 155, 157, 4, 35, 154, 80, 115 } });
        }
    }
}
