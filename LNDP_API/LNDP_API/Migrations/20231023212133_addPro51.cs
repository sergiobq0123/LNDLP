using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "X7sC8k5o3p8N7cKLkf+RX4zbWlbCalqE9DKKxfQhrgo=", "He4tl/sTtU07IHK1y60/dA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "pED4Fn8+v0jViY3uD8hs8PQym+RrBVghVQXRPiyW/nE=", "He4tl/sTtU07IHK1y60/dA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4RAmi9Q3ktKNE8jvdhe4NcSHkqAatE9hC1rAxbjZCwU=", "He4tl/sTtU07IHK1y60/dA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kRkkh46Dsp8TzJcLKdGzc0IAFqtuG42cZ98SxDn3u4E=", "He4tl/sTtU07IHK1y60/dA==" });
        }
    }
}
