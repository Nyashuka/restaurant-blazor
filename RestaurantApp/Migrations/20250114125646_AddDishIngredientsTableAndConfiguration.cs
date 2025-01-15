using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDishIngredientsTableAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredients",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 237, 130, 22, 92, 146, 35, 140, 56, 118, 178, 202, 245, 220, 193, 200, 166, 144, 149, 171, 52, 172, 216, 197, 26, 159, 95, 119, 97, 103, 59, 101, 86, 164, 89, 46, 131, 192, 4, 204, 10, 156, 17, 64, 207, 145, 84, 4, 69, 47, 39, 92, 248, 32, 87, 165, 191, 101, 30, 166, 25, 164, 153, 117, 167 }, new byte[] { 166, 148, 120, 147, 205, 241, 111, 121, 211, 215, 183, 181, 51, 123, 146, 177, 163, 31, 202, 13, 210, 72, 186, 69, 107, 39, 144, 88, 145, 38, 182, 114, 116, 91, 84, 241, 100, 216, 40, 183, 117, 177, 118, 136, 77, 233, 114, 146, 136, 192, 221, 245, 2, 189, 132, 211, 10, 215, 179, 204, 197, 54, 133, 79, 156, 255, 239, 9, 221, 62, 150, 36, 220, 170, 147, 154, 46, 82, 125, 10, 84, 48, 127, 217, 25, 81, 86, 189, 138, 223, 239, 153, 117, 239, 110, 138, 245, 182, 190, 119, 32, 93, 242, 210, 216, 89, 62, 87, 222, 178, 139, 81, 186, 194, 68, 20, 209, 143, 78, 212, 57, 131, 237, 128, 237, 46, 130, 44 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 237, 130, 22, 92, 146, 35, 140, 56, 118, 178, 202, 245, 220, 193, 200, 166, 144, 149, 171, 52, 172, 216, 197, 26, 159, 95, 119, 97, 103, 59, 101, 86, 164, 89, 46, 131, 192, 4, 204, 10, 156, 17, 64, 207, 145, 84, 4, 69, 47, 39, 92, 248, 32, 87, 165, 191, 101, 30, 166, 25, 164, 153, 117, 167 }, new byte[] { 166, 148, 120, 147, 205, 241, 111, 121, 211, 215, 183, 181, 51, 123, 146, 177, 163, 31, 202, 13, 210, 72, 186, 69, 107, 39, 144, 88, 145, 38, 182, 114, 116, 91, 84, 241, 100, 216, 40, 183, 117, 177, 118, 136, 77, 233, 114, 146, 136, 192, 221, 245, 2, 189, 132, 211, 10, 215, 179, 204, 197, 54, 133, 79, 156, 255, 239, 9, 221, 62, 150, 36, 220, 170, 147, 154, 46, 82, 125, 10, 84, 48, 127, 217, 25, 81, 86, 189, 138, 223, 239, 153, 117, 239, 110, 138, 245, 182, 190, 119, 32, 93, 242, 210, 216, 89, 62, 87, 222, 178, 139, 81, 186, 194, 68, 20, 209, 143, 78, 212, 57, 131, 237, 128, 237, 46, 130, 44 } });
        }
    }
}
