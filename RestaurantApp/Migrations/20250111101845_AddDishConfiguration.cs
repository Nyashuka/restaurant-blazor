using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDishConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DishTypeId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    ServingPerUnit = table.Column<int>(type: "integer", nullable: false),
                    PricePerUnit = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_DishTypes_DishTypeId",
                        column: x => x.DishTypeId,
                        principalTable: "DishTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishTypeId",
                table: "Dishes",
                column: "DishTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 }, new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 231, 239, 24, 10, 106, 26, 160, 141, 230, 170, 88, 82, 81, 116, 151, 13, 155, 12, 158, 132, 228, 57, 126, 253, 212, 156, 119, 111, 63, 41, 89, 112, 207, 40, 163, 154, 105, 116, 202, 151, 137, 129, 15, 242, 94, 88, 9, 159, 230, 136, 52, 163, 61, 249, 74, 158, 26, 217, 195, 187, 35, 212, 189 }, new byte[] { 118, 248, 223, 22, 164, 101, 34, 182, 109, 135, 88, 154, 164, 175, 87, 116, 228, 8, 219, 151, 206, 209, 97, 96, 122, 14, 160, 11, 58, 229, 185, 215, 236, 41, 71, 15, 121, 126, 232, 228, 48, 86, 187, 108, 132, 40, 222, 210, 235, 126, 68, 9, 78, 251, 245, 103, 104, 146, 43, 71, 233, 252, 108, 200, 221, 99, 164, 131, 180, 121, 62, 200, 139, 76, 144, 158, 124, 184, 20, 94, 228, 156, 57, 34, 173, 246, 78, 254, 129, 30, 51, 172, 180, 24, 172, 83, 40, 197, 130, 126, 114, 2, 189, 156, 173, 108, 202, 239, 224, 182, 164, 121, 41, 219, 42, 36, 233, 125, 233, 107, 235, 254, 254, 24, 255, 106, 166, 66 } });
        }
    }
}
