using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class nueva5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Dossier");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Dossier",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Dossier",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Dossier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Dossier",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Dossier");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Dossier");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Dossier");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Dossier");

            migrationBuilder.AddColumn<int>(
                name: "Photos",
                table: "Dossier",
                type: "integer",
                nullable: true);
        }
    }
}
