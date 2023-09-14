using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateArtist5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Photo_PhotoId",
                table: "Artist");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Artist_PhotoId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "Photos",
                table: "Dosier",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Artist",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 14, 19, 2, 50, 599, DateTimeKind.Utc).AddTicks(9480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Dosier");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DosierId = table.Column<int>(type: "integer", nullable: true),
                    Imagen = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Dosier_DosierId",
                        column: x => x.DosierId,
                        principalTable: "Dosier",
                        principalColumn: "Id");
                });

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
                name: "IX_Artist_PhotoId",
                table: "Artist",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_DosierId",
                table: "Photo",
                column: "DosierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Photo_PhotoId",
                table: "Artist",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");
        }
    }
}
