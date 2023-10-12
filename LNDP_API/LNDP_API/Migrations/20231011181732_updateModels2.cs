using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Collaboration",
                newName: "WebUrl");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Collaboration",
                newName: "PhotoUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebUrl",
                table: "Collaboration",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Collaboration",
                newName: "Photo");
        }
    }
}
