using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "UserRoleId", "Username" },
                values: new object[,]
                {
                    { 1, "Sanchez", "Lba5JggMI10RnoaliB+WDXyUVwBxcx0vYkmoO8jaK+c=", "APO/YEKH40O90n4k0j2UJA==", 1, "Sanchez" },
                    { 2, "Torres", "zIZJYkJDA5qPRItPkyG3fQ14yxJIOO90FkRkIR1vLvk=", "APO/YEKH40O90n4k0j2UJA==", 1, "Torres" },
                    { 3, "Tomas", "mOfJ5MGG4ZTKGrh/B+PGLn6bWnhSZn+uQyWfo6nfwH8=", "APO/YEKH40O90n4k0j2UJA==", 1, "Tomas" },
                    { 4, "Iglesias", "KxlmYemi5wV9YNVwsG2wNe8em/c5dYbPx2MMPNDeCU8=", "APO/YEKH40O90n4k0j2UJA==", 2, "Iglesias" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
