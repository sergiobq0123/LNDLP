using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
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
                values: new object[] { "WtuE00i1+LvCWzX/yPq9bV0lnYIXU1jcbMPyQTFUrP8=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6TNzs5g/gAP8J/i4tDjBDDuKs4rBc/q1Ry+uyl2ZvEE=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "E/Yo/JIyHZh7Y660dGLgKEnlNPD4vWUy8E+cEW1SP9Q=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "w2m1E06gCqKc9/kgk3BeztNijRPUi9eTGzPnO/Tcrkc=", "rg7D8/hAcg3HBrGqCG6cmw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
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
    }
}
