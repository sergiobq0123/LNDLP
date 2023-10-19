using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    UrlLocation = table.Column<string>(type: "text", nullable: true),
                    Tickets = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistFestivalAsoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FestivalId = table.Column<int>(type: "integer", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFestivalAsoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistFestivalAsoc_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFestivalAsoc_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5Uxrhfcd8wUuJGa70KVOZrmsncyv6kkZXVgidolfpBg=", "2uksmPJ5URgLlkZZkQ/Qqw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9kixWYEse+bTy5ObDuCHZG+o8rcfiNq8XQxBh9tWx1Q=", "2uksmPJ5URgLlkZZkQ/Qqw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MBfy7s3lfh0ccgxH2JIliwG8UcIIus62pbMblR36nHM=", "2uksmPJ5URgLlkZZkQ/Qqw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g8DaJx0XFoHtBNVIK3uePDo6Mi4eF083s2vj1UWh5ec=", "2uksmPJ5URgLlkZZkQ/Qqw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestivalAsoc_ArtistId",
                table: "ArtistFestivalAsoc",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestivalAsoc_FestivalId",
                table: "ArtistFestivalAsoc",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistFestivalAsoc");

            migrationBuilder.DropTable(
                name: "Festival");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "D6Lr0mYYTVDUD+CELlMU6LrdW2k8DCU2ylFGFkfQGrk=", "YBNLXAgoJJ6GixHzatjcPg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ChuVQOv0mFUKQVSl1Z8QChvxgpYU35ld9iwy6ALn+aM=", "YBNLXAgoJJ6GixHzatjcPg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "GwNne4q4Ili4hYRUJZXHP+dVCAtHAVHJisiX/Ycooco=", "YBNLXAgoJJ6GixHzatjcPg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "gyXwIAwWhGQlHt78OvGtrV9SHx9CC0CnmrIJVIzszGw=", "YBNLXAgoJJ6GixHzatjcPg==" });
        }
    }
}
