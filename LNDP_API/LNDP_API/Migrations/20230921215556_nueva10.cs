using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class nueva10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
