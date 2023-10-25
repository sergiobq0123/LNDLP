using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRole",
                newName: "Role");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "z4NRlgBKMjb/9jUdwyEGL53m2OLYQL4ZOr1K1+Cn0KA=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MXWZR5Pf98gKlZj1lIBppI0wK96VcmOET8iCgPDJ70o=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ZXtsQXLxppwrrDIiXYJNUN4nmLip9iIjR+Yhx5Q6dT0=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YMGicJvYg2F++FDcXuMmBPHuUWhOUIKa8uJmq13QTYg=", "lu7lO643JcUbgi5Bx4PyBw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserRole",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/+I/kAWObg51/2JPnIsfFdaBvB27Gv6WBAjsDi2Hk4s=", "bjEFFGTpZgt6eLAAfu/PAg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "nSu81MMpm0cFt4HRA5GOWfQf3c8ug+N5sFZPBwcij68=", "bjEFFGTpZgt6eLAAfu/PAg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1lUdaIeYuwk8vBJRZa3sqa5HZKlup0Feha47Q7aMct0=", "bjEFFGTpZgt6eLAAfu/PAg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "V/jwUNU/BrPEGPrUY4Su8uHFq6MRcsbj4IYu4t332Lg=", "bjEFFGTpZgt6eLAAfu/PAg==" });
        }
    }
}
