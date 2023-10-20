using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "nOJwRAnMQv1IznImgP52MhTdhQhCx3UUicbXvdb1xLk=", "05ohbwjIBic0Z07g+2Ca8g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "tjcfps3YiI4MWeednqiafUWYqVS4qQCQS1FseVy+qAE=", "05ohbwjIBic0Z07g+2Ca8g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Oynl5mHB5HgYEm8CfnZnIz33z9dCBXT/8kQ5FoeEgNg=", "05ohbwjIBic0Z07g+2Ca8g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1Kc0oN/x9dQeCBTxmoPLc4gc7C0c0mreSRO56bwRZqA=", "05ohbwjIBic0Z07g+2Ca8g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6wX6u27lLI5HCdDrLdbBfJuUjUnXQQIYdwHH6P1JUrI=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "T3ckPksMUaOBd5tkjoCnLi63Fs9oyDuzVseNGBAj7LU=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ldA6H5Zs6yRV+xQTb3/3XrBiFEBgXz6Ur4Sa+w2gMcc=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Oj8M5FW+fP+RJ4BXyyDugpRbIeUKKCIgp5syFYcZY2U=", "SgBHyPwqZSwkw/st41Khyg==" });
        }
    }
}
