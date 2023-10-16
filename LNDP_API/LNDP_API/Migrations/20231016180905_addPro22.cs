using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YoutubeVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeVideo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FWerW6AFj2TFX+wbihAAclIwme/CbQZUKG8qxGgaGRE=", "QrluPwhA9qwG5QqdDkS2oQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0aXJoSfwmM2leRNWV+UKAJZoK0dBUcSREYbzkXSZDNE=", "QrluPwhA9qwG5QqdDkS2oQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "L5GGCJnO/HBeWJ0r6kGazt2tFi/rk3SiSRJfJ2K9vms=", "QrluPwhA9qwG5QqdDkS2oQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Rxckb5dN6yrpuFPexmwlMvs8Veyyp/h9spmeY9hkBRc=", "QrluPwhA9qwG5QqdDkS2oQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YoutubeVideo");

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
        }
    }
}
