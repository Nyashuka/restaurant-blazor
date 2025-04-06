using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    AmountPaid = table.Column<double>(type: "double precision", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 31, 45, 183, 50, 74, 237, 57, 187, 77, 241, 22, 235, 33, 19, 181, 116, 18, 134, 184, 148, 181, 15, 205, 199, 106, 22, 200, 95, 196, 8, 56, 227, 112, 203, 86, 248, 195, 247, 197, 4, 170, 67, 202, 7, 31, 93, 56, 221, 170, 178, 223, 198, 175, 56, 180, 181, 56, 16, 125, 81, 92, 141, 245 }, new byte[] { 161, 125, 32, 44, 76, 43, 23, 252, 102, 7, 74, 105, 21, 109, 245, 159, 38, 251, 9, 21, 80, 253, 4, 152, 165, 200, 208, 159, 255, 67, 57, 222, 83, 105, 41, 48, 122, 243, 54, 29, 17, 152, 72, 203, 199, 109, 192, 223, 78, 189, 8, 249, 93, 240, 5, 104, 97, 125, 208, 158, 201, 157, 123, 121, 67, 34, 198, 133, 1, 83, 33, 25, 182, 171, 80, 48, 67, 181, 218, 203, 38, 22, 191, 126, 131, 86, 16, 117, 139, 102, 116, 226, 30, 42, 18, 58, 208, 8, 240, 176, 255, 184, 218, 48, 101, 83, 194, 179, 196, 136, 110, 98, 65, 59, 8, 168, 115, 119, 105, 189, 161, 251, 223, 157, 130, 209, 148, 57 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 31, 45, 183, 50, 74, 237, 57, 187, 77, 241, 22, 235, 33, 19, 181, 116, 18, 134, 184, 148, 181, 15, 205, 199, 106, 22, 200, 95, 196, 8, 56, 227, 112, 203, 86, 248, 195, 247, 197, 4, 170, 67, 202, 7, 31, 93, 56, 221, 170, 178, 223, 198, 175, 56, 180, 181, 56, 16, 125, 81, 92, 141, 245 }, new byte[] { 161, 125, 32, 44, 76, 43, 23, 252, 102, 7, 74, 105, 21, 109, 245, 159, 38, 251, 9, 21, 80, 253, 4, 152, 165, 200, 208, 159, 255, 67, 57, 222, 83, 105, 41, 48, 122, 243, 54, 29, 17, 152, 72, 203, 199, 109, 192, 223, 78, 189, 8, 249, 93, 240, 5, 104, 97, 125, 208, 158, 201, 157, 123, 121, 67, 34, 198, 133, 1, 83, 33, 25, 182, 171, 80, 48, 67, 181, 218, 203, 38, 22, 191, 126, 131, 86, 16, 117, 139, 102, 116, 226, 30, 42, 18, 58, 208, 8, 240, 176, 255, 184, 218, 48, 101, 83, 194, 179, 196, 136, 110, 98, 65, 59, 8, 168, 115, 119, 105, 189, 161, 251, 223, 157, 130, 209, 148, 57 } });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

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
        }
    }
}
