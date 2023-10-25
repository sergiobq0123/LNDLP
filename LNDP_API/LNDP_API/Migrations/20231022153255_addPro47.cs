using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "707CVuAkcqmp1uSYLr4xdy6dYxBYk2+bwUzQY03b+bc=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6jLqxASrxXaNI9Rkh7N0Zd5sXZO7ddA/uWIm8HgC4eU=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "DDR5fl2b3TgVaoe+2vTuCbupHebL1F0APTAd1gOJ9Us=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lbYsok7jp/upvcwHzNpjAh/JiHHnY9J9zLVaGoeJpY8=", "sZ9EqOv0jExYrOBkm2yTYQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/Ok+2dElHdTPIvqBMQP5xcx25wSMzkwpbAkdVdXF5Ag=", "ezAikJ4RQQWzWaUE7LgtjQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CeuPBD22GOns43moIgfJR41Z8rm0Y5wCfBU1QwKnVpU=", "ezAikJ4RQQWzWaUE7LgtjQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/0IBBM0vopkJwtbWXyUxKELCEc33cSyIYAP2GPl0xSY=", "ezAikJ4RQQWzWaUE7LgtjQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "qfTFZmxrZi0zbVGvdan/gPBHXeLH5YNGzdFQEOEn6WA=", "ezAikJ4RQQWzWaUE7LgtjQ==" });
        }
    }
}
