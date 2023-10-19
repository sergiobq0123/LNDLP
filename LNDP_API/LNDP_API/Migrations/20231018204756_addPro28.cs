using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Company",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Company",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
