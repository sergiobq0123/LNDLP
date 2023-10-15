using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Visual");

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Role" },
                values: new object[] { 3, "Crew" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Crew");
        }
    }
}
