using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UserId",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "SocialNetwork",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Crew",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 8, 29, 593, DateTimeKind.Utc).AddTicks(5971));

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId",
                table: "Artist",
                column: "CrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist",
                column: "SocialNetworkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UserId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "SocialNetwork");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Crew");

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId",
                table: "Artist",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                column: "UserId");
        }
    }
}
