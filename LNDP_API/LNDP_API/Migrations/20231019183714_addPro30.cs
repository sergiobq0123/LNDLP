using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "User",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Acces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acces_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Acces",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "kMR5LuKXwNlBMGDWsIC7x6QG1qgY9dnFkt6udRhpE94=", "PQXj1QbX9NThmPdhDI8I5A==", 1, "Sanchez" },
                    { 2, "lB0x+FmcyUqDNxRYfbd68cTU6mzxNJTwru5g1cAwL+M=", "PQXj1QbX9NThmPdhDI8I5A==", 2, "Torres" },
                    { 3, "byS1uBG9/+dJS7aP2t01oFGeKAg5714yZ6Ik9EscyT8=", "PQXj1QbX9NThmPdhDI8I5A==", 3, "Tomas" },
                    { 4, "5+Wt56G/fzvgQ2RwraevpRaQrqWhC7VcB8TXyE8g++A=", "PQXj1QbX9NThmPdhDI8I5A==", 4, "Iglesias" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sergio");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jorge");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Tomas", "De la Fuente" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Alvaro");

            migrationBuilder.CreateIndex(
                name: "IX_Acces_UserId",
                table: "Acces",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acces");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AqGF5Fl0uoqEGy/E9JRrDjylmFy96AbWqQjUpHJ6Vd0=", "nBrH0EttMSvGpGh+/Dcqkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YVLucdxZyLqP2Wg9vC3Y7Jw8MqlClzt99JLd0KbGpGU=", "nBrH0EttMSvGpGh+/Dcqkg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "HjeYdeXCjkZbLQQEG3STXalPoyM9cpX21BVxWTwXrGM=", "nBrH0EttMSvGpGh+/Dcqkg==", "Tomas" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kO13BArkmh5rFdj+/+5mr9JEV9H4ZtPesRHnaLbif9A=", "nBrH0EttMSvGpGh+/Dcqkg==" });
        }
    }
}
