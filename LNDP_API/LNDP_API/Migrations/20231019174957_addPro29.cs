using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AqGF5Fl0uoqEGy/E9JRrDjylmFy96AbWqQjUpHJ6Vd0=", "nBrH0EttMSvGpGh+/Dcqkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YVLucdxZyLqP2Wg9vC3Y7Jw8MqlClzt99JLd0KbGpGU=", "nBrH0EttMSvGpGh+/Dcqkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HjeYdeXCjkZbLQQEG3STXalPoyM9cpX21BVxWTwXrGM=", "nBrH0EttMSvGpGh+/Dcqkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kO13BArkmh5rFdj+/+5mr9JEV9H4ZtPesRHnaLbif9A=", "nBrH0EttMSvGpGh+/Dcqkg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "cjLHPiVTQGiTcxUREaPDDsF86a1XFtxm8TNcC+SyPDE=", "K8Ec2j2/KDgbUc/XblXu0Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5nclhORa4Cngy8zaXA630byOO13eWoMH/Cl7idlbJVc=", "K8Ec2j2/KDgbUc/XblXu0Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "57RFU5uj5VbWDfUfu6/ZFK7nvvTrp7mV4LWQ+pTukRo=", "K8Ec2j2/KDgbUc/XblXu0Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "iu4nziSpOfnntpS9+FpLFOFnvzuvNOBhjlwmWkgF1/A=", "K8Ec2j2/KDgbUc/XblXu0Q==" });
        }
    }
}
