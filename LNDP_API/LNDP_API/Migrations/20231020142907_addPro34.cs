using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Sp+crz/dVMfCV13592jprBNdKkOzoRGSfpqy1HKGfV4=", "ASTesMQre8gJHAZHFTKQXQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5Kafu3tsETYTnwHRXPSrLHg4dAWO39uxPLUid+EDaUc=", "ASTesMQre8gJHAZHFTKQXQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CBzW92RvM2/jW6oYdwKNCDfbKde/+Rk/dEflToAOZRw=", "ASTesMQre8gJHAZHFTKQXQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "npKhPOE6MJDoA0WGdI2e7cchGju0nBrwIophB3sDSZM=", "ASTesMQre8gJHAZHFTKQXQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
