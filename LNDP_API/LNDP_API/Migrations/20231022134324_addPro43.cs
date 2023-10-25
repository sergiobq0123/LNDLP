using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Artist",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "P0v9WC3cROjwPhHquPC9SnfdopMOE5edZb98vrOu5G4=", "LyYJ5mmtLXnhciBDh+7Jpg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8O60C3Wm2rAJf8zi9S+BYCg4MhIzAy/mo1oKJO2zTns=", "LyYJ5mmtLXnhciBDh+7Jpg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fIwnVp+szb4+f80PBJDQSP/rrXZxR6CX2ICMzwsWD68=", "LyYJ5mmtLXnhciBDh+7Jpg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "I2b8Q+6i2afCVcuyyuqYZ7HWZhEJrl/M5anqbuTvjGc=", "LyYJ5mmtLXnhciBDh+7Jpg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Artist",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fdHsNzbny0t/aATYFELCst2MyMPg4FgXy5oPR9jhT2k=", "0R2yfaiWhjlZnlHhvxIaJA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wlKHmKHtKjzTxkjC1oPda7Dqps7ctAPwZZF/nCb4Y8o=", "0R2yfaiWhjlZnlHhvxIaJA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MKQz3iKleOdso347+wmIcIh9+OSCl6Dg799DtFACqxo=", "0R2yfaiWhjlZnlHhvxIaJA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "95Rz2fZiT8aqLUe2EXVmYnxoTVYYb4jpLxAPOWDVWss=", "0R2yfaiWhjlZnlHhvxIaJA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
