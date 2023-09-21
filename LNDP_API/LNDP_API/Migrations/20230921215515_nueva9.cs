using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class nueva9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
