using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FtpJB1ZE5DQrJOZ9LRF0nNv3UJ9OYgOf8vlRvPdtXrg=", "kGtKdhwH9RgChZzVY3XPjA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sA0+njIcmBxnJmq2C4L7bqIxjizs8e6WJ8ovgQf1+g0=", "kGtKdhwH9RgChZzVY3XPjA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1aKIJi+oOarggCyeRLNdb3MaK46o1pbhitqSGzkmPwA=", "kGtKdhwH9RgChZzVY3XPjA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+rp2Vp+4n1SbPaT2SFmSp3gu1JH7iDaNpXEDyS2LgAA=", "kGtKdhwH9RgChZzVY3XPjA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9UozMMevOyJG3kcG4aQbFqHMh7Kx0aFq0hdJ+JviidU=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "w8tACNSZJuESyCaz9J971/gxqIkUZ2VzlnREhNZPDvM=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "3r+wa8ndGOX47PwRbrP1tKQXyOLxcSg5+rtkBKYFw9A=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Rjr9DZHxurEKUYhpz5HZuwc3MLcX9q8Rt+c67RcZup4=", "w+4JBee9Gr1B4aUDmwLiTw==" });
        }
    }
}
