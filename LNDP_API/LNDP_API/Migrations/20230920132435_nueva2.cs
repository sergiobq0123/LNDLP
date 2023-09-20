using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class nueva2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosier",
                table: "Dosier");

            migrationBuilder.RenameTable(
                name: "Dosier",
                newName: "Dossier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dossier",
                table: "Dossier",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dossier",
                table: "Dossier");

            migrationBuilder.RenameTable(
                name: "Dossier",
                newName: "Dosier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosier",
                table: "Dosier",
                column: "Id");
        }
    }
}
