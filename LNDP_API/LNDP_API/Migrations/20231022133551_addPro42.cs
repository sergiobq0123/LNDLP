using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acces_User_UserId",
                table: "Acces");

            migrationBuilder.DropIndex(
                name: "IX_Acces_UserId",
                table: "Acces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Acces");

            migrationBuilder.AddColumn<int>(
                name: "AccesId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "AccesId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "AccesId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccesId",
                table: "User",
                column: "AccesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Acces_AccesId",
                table: "User",
                column: "AccesId",
                principalTable: "Acces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Acces_AccesId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccesId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Acces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserId" },
                values: new object[] { "z9rCRw6TIzYz/HaqlrYRtIP7oaATyrBvzZJHd9pV9bw=", "F7a4c7kKFNFWMaFnHcjsyQ==", 1 });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserId" },
                values: new object[] { "zeNENACmg0lFlqkgysyGOWi3L26T/Y4u1rw4ToJYMlE=", "F7a4c7kKFNFWMaFnHcjsyQ==", 2 });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserId" },
                values: new object[] { "mScgB4S5qDAInS5Sr9fabZczd/zj1njf4uVJTEWHzTg=", "F7a4c7kKFNFWMaFnHcjsyQ==", 3 });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt", "UserId" },
                values: new object[] { "5K8abdSrxlPc5l+Y0/0buG17rg8i1v9FfYGWzRsQlco=", "F7a4c7kKFNFWMaFnHcjsyQ==", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Acces_UserId",
                table: "Acces",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acces_User_UserId",
                table: "Acces",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
