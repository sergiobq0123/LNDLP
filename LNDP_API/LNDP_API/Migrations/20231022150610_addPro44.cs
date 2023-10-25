using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+5OxEVv4jLK12nC/24Cb7eJWAkTOfuu7pcebALH9N70=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YVL63FfQI4ipcs5ZftIrSdVkTDzKmrdGac12EO2tMds=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5DH/65koPZ2Rrcm6EjXvsQbygFNDRedF/6oh9b7Muxw=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lBxzjFhhr5age0taC02615rLazvpHmuXNABVdSJrG+U=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "User",
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
        }
    }
}
