using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro46 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FED8LitOQKXcymnIKgciU6rbrHa552Hw3ctncwNJxto=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "uH3jXn3CDUkb4r0a6dblbMwL7SJYi0W8eU9L/g37l9U=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SlqjeZ0OHB3oXDdDBm/OaRWsvo2BdRo4/5LZYtCscFM=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "04TWdywReOVIalgJAnBzLB7t8nYCPiCSxz92PcxZ+rg=", "RY1YlPXdupt9oHVm0cTxEQ==" });
        }
    }
}
