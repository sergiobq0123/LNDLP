using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Song",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "07Wk9J4y3dTaXi6SLaF27Cb0FuWpiPnLTHcZOc3/l9I=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "aLKOh7Kv88NTLMprfg9an8zb8XJEsc1quyhsrPC9+9g=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ZGYuyOY1iHRJ8wSpb6FqIGbzMMuXf5Di9xbVqHSGGJI=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Zgok9NmDi9jySFjEX+DFdDmfRobggcCycMrBo9jKn8k=", "g32sc7ZL2qG1Xc/xpM8fPw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Song",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FI6y/vUqJ5oRtNaecfGN1PZCZ7R3MMOeNceV4HzAeos=", "ZZLdwqA2hgMaLaRJ57V7fQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/1QbAgmxXbJ3gaPvKqiFdG4U4A6pDXGDoYrQ/XeUKSs=", "ZZLdwqA2hgMaLaRJ57V7fQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "zHQbvegcXjyYNOjSBb/JhnElBQ0fm6UgCSNB2ciSCWo=", "ZZLdwqA2hgMaLaRJ57V7fQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "PiNo7XLN0o3m3Or1nU18pcAuAKXQ8C+QHaj+LfbCQPg=", "ZZLdwqA2hgMaLaRJ57V7fQ==" });
        }
    }
}
