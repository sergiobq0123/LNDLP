using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistFestivalAsoc",
                table: "ArtistFestivalAsoc");

            migrationBuilder.DropIndex(
                name: "IX_ArtistFestivalAsoc_FestivalId",
                table: "ArtistFestivalAsoc");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ArtistFestivalAsoc",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistFestivalAsoc",
                table: "ArtistFestivalAsoc",
                columns: new[] { "FestivalId", "ArtistId" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9UozMMevOyJG3kcG4aQbFqHMh7Kx0aFq0hdJ+JviidU=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "w8tACNSZJuESyCaz9J971/gxqIkUZ2VzlnREhNZPDvM=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "3r+wa8ndGOX47PwRbrP1tKQXyOLxcSg5+rtkBKYFw9A=", "w+4JBee9Gr1B4aUDmwLiTw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Rjr9DZHxurEKUYhpz5HZuwc3MLcX9q8Rt+c67RcZup4=", "w+4JBee9Gr1B4aUDmwLiTw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistFestivalAsoc",
                table: "ArtistFestivalAsoc");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ArtistFestivalAsoc",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistFestivalAsoc",
                table: "ArtistFestivalAsoc",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8SNhv8VJALdfU2YzXwNFB1v+OpJwHIGeL7BH2fxPWGE=", "5QZqcihkiqHLQr7iyJ1+Xw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rSdeNcfP6EnSbucAJgu6Lw1sJmMH+uSeOZzRhYQV9BM=", "5QZqcihkiqHLQr7iyJ1+Xw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fsg8U6naMO0fl95ALGmxVpkxYqJQk4nEXWcYfFJtdZ8=", "5QZqcihkiqHLQr7iyJ1+Xw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "x8ryE2Xz13VLDqrnNQmmMM5XduSVsn9a76//6q442iY=", "5QZqcihkiqHLQr7iyJ1+Xw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestivalAsoc_FestivalId",
                table: "ArtistFestivalAsoc",
                column: "FestivalId");
        }
    }
}
