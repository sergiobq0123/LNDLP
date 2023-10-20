using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yi8n/rNk6KlUd2sPa+QxdVqD17FYugPcbah3VNJ0IpQ=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "qYtKz4ejpBOblhsZ6dgiw++oTL3jKBRkIHZ3+H9zkaM=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lMBQK0RCgHfnPfZ4rKysQBDViDnzSdTT2zUn6g02hnc=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "jYEkrvFfX6ING87R/KQfHOBqpDFrO4WcF4Cm7ZsI9Ms=", "m0Kd+YW76aNmB4cun4XT/g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
