using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateArtist4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_Id",
                table: "Crew");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Artist_Id",
                table: "SocialNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Artist_Id",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SocialNetwork",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Crew",
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
                value: new DateTime(2023, 9, 14, 16, 6, 40, 679, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 16, 6, 40, 679, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 16, 6, 40, 679, DateTimeKind.Utc).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 16, 6, 40, 679, DateTimeKind.Utc).AddTicks(3291));

            migrationBuilder.CreateIndex(
                name: "IX_User_ArtistId",
                table: "User",
                column: "ArtistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetwork_ArtistId",
                table: "SocialNetwork",
                column: "ArtistId",
                unique: true);

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Artist_ArtistId",
                table: "User",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Artist_ArtistId",
                table: "Crew");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Artist_ArtistId",
                table: "SocialNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Artist_ArtistId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ArtistId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetwork_ArtistId",
                table: "SocialNetwork");

            migrationBuilder.DropIndex(
                name: "IX_Crew_ArtistId",
                table: "Crew");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SocialNetwork",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Crew",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialNetworkId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 56, 9, 229, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 56, 9, 229, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 56, 9, 229, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 15, 56, 9, 229, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Artist_Id",
                table: "Crew",
                column: "Id",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Artist_Id",
                table: "SocialNetwork",
                column: "Id",
                principalTable: "Artist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Artist_Id",
                table: "User",
                column: "Id",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
