using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class fixArtistCrew4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_ArtistiD",
                table: "Crew");

            migrationBuilder.DropIndex(
                name: "IX_Crew_ArtistiD",
                table: "Crew");

            migrationBuilder.RenameColumn(
                name: "ArtistiD",
                table: "Crew",
                newName: "ArtistId");

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrewId1",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 9, 43, 683, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 9, 43, 683, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 9, 43, 683, DateTimeKind.Utc).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 9, 43, 683, DateTimeKind.Utc).AddTicks(7717));

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId1",
                table: "Artist",
                column: "CrewId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_CrewId1",
                table: "Artist",
                column: "CrewId1",
                principalTable: "Crew",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_CrewId1",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId1",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "CrewId1",
                table: "Artist");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Crew",
                newName: "ArtistiD");

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 5, 17, 17, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 5, 17, 17, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 5, 17, 17, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 18, 5, 17, 17, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.CreateIndex(
                name: "IX_Crew_ArtistiD",
                table: "Crew",
                column: "ArtistiD",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Artist_ArtistiD",
                table: "Crew",
                column: "ArtistiD",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
