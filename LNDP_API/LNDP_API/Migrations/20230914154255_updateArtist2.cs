using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateArtist2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_SocialNetwork_SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UserId",
                table: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Artist",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 42, 55, 111, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 42, 55, 111, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 42, 55, 111, DateTimeKind.Utc).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 42, 55, 111, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_Id",
                table: "Artist",
                column: "Id",
                principalTable: "Crew",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_SocialNetwork_Id",
                table: "Artist",
                column: "Id",
                principalTable: "SocialNetwork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_Id",
                table: "Artist",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_Id",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_SocialNetwork_Id",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_Id",
                table: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Artist",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_SocialNetwork_SocialNetworkId",
                table: "Artist",
                column: "SocialNetworkId",
                principalTable: "SocialNetwork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
