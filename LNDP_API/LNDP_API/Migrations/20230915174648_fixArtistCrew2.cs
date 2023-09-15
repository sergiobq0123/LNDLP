using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class fixArtistCrew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew");

            migrationBuilder.DropIndex(
                name: "IX_Crew_ArtistId",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Crew");

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 17, 46, 48, 259, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 17, 46, 48, 259, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 17, 46, 48, 259, DateTimeKind.Utc).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 17, 46, 48, 259, DateTimeKind.Utc).AddTicks(495));

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId",
                table: "Artist",
                column: "CrewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Crew",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 16, 3, 24, 956, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 16, 3, 24, 956, DateTimeKind.Utc).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 16, 3, 24, 956, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 16, 3, 24, 956, DateTimeKind.Utc).AddTicks(1305));

            migrationBuilder.CreateIndex(
                name: "IX_Crew_ArtistId",
                table: "Crew",
                column: "ArtistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
