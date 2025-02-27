using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationOrderAndEventType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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


            migrationBuilder.Sql("UPDATE \"Orders\" SET \"EventTypeId\"= 1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EventTypeId",
                table: "Orders",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_EventTypes_EventTypeId",
                table: "Orders",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_EventTypes_EventTypeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EventTypeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Orders");

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
        }
    }
}
