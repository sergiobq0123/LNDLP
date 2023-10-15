using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RMhavNDpQUqoDKr2+WsYBY1+7AoVp6u1nO7gToXUkvU=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4bR9jOOFV14pkozpiK2wo1US3SzSU3ew+bg2hiSqnZc=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "StBmBFv2L1HjEzAzk/fVW369rOaWvvyxbtS83po2ceY=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2ttcBUZUDfHdAYPBPQ6Ky/hrf9pkNEzXYg5phTVZzBA=", "BUgd71PLdir0eNCk3ODN5g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Lba5JggMI10RnoaliB+WDXyUVwBxcx0vYkmoO8jaK+c=", "APO/YEKH40O90n4k0j2UJA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "zIZJYkJDA5qPRItPkyG3fQ14yxJIOO90FkRkIR1vLvk=", "APO/YEKH40O90n4k0j2UJA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mOfJ5MGG4ZTKGrh/B+PGLn6bWnhSZn+uQyWfo6nfwH8=", "APO/YEKH40O90n4k0j2UJA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "KxlmYemi5wV9YNVwsG2wNe8em/c5dYbPx2MMPNDeCU8=", "APO/YEKH40O90n4k0j2UJA==" });
        }
    }
}
