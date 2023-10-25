using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Festival",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "3LwO7cb6lCrgMmZVPBEWLAmgTRu3BHb7Lq1I6LOxpiw=", "S7MCocrtGR8xmACnBLr6rw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "KybTMsuxlCgfsXadgJlKyhPAN+Q9pQRwTLFQvarIShE=", "S7MCocrtGR8xmACnBLr6rw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1/qJ2mR7umv7xQm9T1c76zRtjNGv5dsyooVpuiHwfU0=", "S7MCocrtGR8xmACnBLr6rw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Rq1wNXqEIpBL+zlaIr+1/UQk66PT9aNbZehoAVmaXL8=", "S7MCocrtGR8xmACnBLr6rw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Festival",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
