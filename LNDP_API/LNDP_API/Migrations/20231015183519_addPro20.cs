using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crew");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    Dj = table.Column<string>(type: "text", nullable: true),
                    LightingTechnician = table.Column<string>(type: "text", nullable: true),
                    RoadManager = table.Column<string>(type: "text", nullable: true),
                    SoundTechnician = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "07Wk9J4y3dTaXi6SLaF27Cb0FuWpiPnLTHcZOc3/l9I=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "aLKOh7Kv88NTLMprfg9an8zb8XJEsc1quyhsrPC9+9g=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ZGYuyOY1iHRJ8wSpb6FqIGbzMMuXf5Di9xbVqHSGGJI=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Zgok9NmDi9jySFjEX+DFdDmfRobggcCycMrBo9jKn8k=", "g32sc7ZL2qG1Xc/xpM8fPw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Crew_ArtistId",
                table: "Crew",
                column: "ArtistId",
                unique: true);
        }
    }
}
