using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "I3FZW4sHbXygJ+ACgRK+OKysJVD6tjDZM4a889EhhQY=", "85+swRrQ+/N84TMHX7QfGw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Sr5M7uvhRbt+xzhicdMoadH/QtUOesm933mACyZO89g=", "85+swRrQ+/N84TMHX7QfGw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "3Oh2TT7JYLFekdzbJEIm3FHUunDg5SYJOVgR/T9jE4s=", "85+swRrQ+/N84TMHX7QfGw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HdvblA31cj6CCMk7MIX4btgSBU5ptK9eTulp0rR7Rg0=", "85+swRrQ+/N84TMHX7QfGw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "t+fE6GpcKkgjzfT69V6sw8KzQGMjB17aJ/w/ttIAvTw=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "WspuyZi4mECedcUIjhC/gm33Thw4BZT0pz3BXP6SWHo=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "B1XWlyZOEY99AABghZ9bSMtCv/yUKR2aXkBIM58ZzAc=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SnutaNMde71s8qmOtSxqCOYQ4Ghq+X3LHrwhu9xyRXY=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });
        }
    }
}
