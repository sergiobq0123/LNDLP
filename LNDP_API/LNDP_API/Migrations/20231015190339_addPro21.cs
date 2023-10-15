using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    UrlLocation = table.Column<string>(type: "text", nullable: true),
                    Tickets = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArtistId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "jegQi9l9Fpm1doz0zt33xJsKgiEDhwgV08cWL4ok2xs=", "QLBJ6jAaQ7cme5So7jKyeA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "oXLSVKECeakpXRkIlSbrNyVWj63AoC9gHz/W/mi2nUc=", "QLBJ6jAaQ7cme5So7jKyeA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "UZpR/6cF+AU9U0euZ5KdVMYyVgD8w38zAdUFVstL0OA=", "QLBJ6jAaQ7cme5So7jKyeA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "7xiu/CwHA2DNI4qmXdqcHrvwIWsxnuh9y75UEPQOzfc=", "QLBJ6jAaQ7cme5So7jKyeA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Concert_ArtistId",
                table: "Concert",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ZaMvRVQMshgo/y8V3WUK/lfzkd5lzOWUzHW9ldf9saE=", "T1L2rT2oBp4KzLSCKh3dtA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "nrmwvylx5pgh1L//916wIsvyJqCfsLRoGQNFxfkMlIk=", "T1L2rT2oBp4KzLSCKh3dtA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wfkc1pOyPyOn4xcvdsBfHY9tXmRKP0PyquGNlHEI+Dw=", "T1L2rT2oBp4KzLSCKh3dtA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FffLekegpGOkuV4IVPYpRevLxuxTMSxUqgK+aHMIYI8=", "T1L2rT2oBp4KzLSCKh3dtA==" });
        }
    }
}
