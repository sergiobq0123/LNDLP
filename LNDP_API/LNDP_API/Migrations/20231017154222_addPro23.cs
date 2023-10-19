using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Artist_ArtistId",
                table: "Concert");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Artist_ArtistId",
                table: "Concert",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Artist_ArtistId",
                table: "Concert");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Artist_ArtistId",
                table: "Concert",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
