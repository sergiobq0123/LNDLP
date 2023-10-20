using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6wX6u27lLI5HCdDrLdbBfJuUjUnXQQIYdwHH6P1JUrI=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "T3ckPksMUaOBd5tkjoCnLi63Fs9oyDuzVseNGBAj7LU=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ldA6H5Zs6yRV+xQTb3/3XrBiFEBgXz6Ur4Sa+w2gMcc=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Oj8M5FW+fP+RJ4BXyyDugpRbIeUKKCIgp5syFYcZY2U=", "SgBHyPwqZSwkw/st41Khyg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestivalAsoc_FestivalId",
                table: "ArtistFestivalAsoc",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yi8n/rNk6KlUd2sPa+QxdVqD17FYugPcbah3VNJ0IpQ=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "qYtKz4ejpBOblhsZ6dgiw++oTL3jKBRkIHZ3+H9zkaM=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lMBQK0RCgHfnPfZ4rKysQBDViDnzSdTT2zUn6g02hnc=", "m0Kd+YW76aNmB4cun4XT/g==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "jYEkrvFfX6ING87R/KQfHOBqpDFrO4WcF4Cm7ZsI9Ms=", "m0Kd+YW76aNmB4cun4XT/g==" });
        }
    }
}
