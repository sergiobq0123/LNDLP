using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Record",
                newName: "WebUrl");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Record",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Brand",
                newName: "WebUrl");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Brand",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Album",
                newName: "WebUrl");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Album",
                newName: "PhotoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Song",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebUrl",
                table: "Record",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Record",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "WebUrl",
                table: "Brand",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Brand",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "WebUrl",
                table: "Album",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Album",
                newName: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Song",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
