using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Festival",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "hqGjeZaNY8WUfzecBOsVPtrDrd1hjsc3vvrCIIScp3I=", "c9hPd5GDg/9Nyw5B+56KwQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "n0jMUt233KVWRfLVtNc+b+RRR1dc0x5hbwXaJbm63V0=", "c9hPd5GDg/9Nyw5B+56KwQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "UFbaC+jgIiWdxY9JldURMAv/ESBconIQZesVlttbSrk=", "c9hPd5GDg/9Nyw5B+56KwQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "WE8nOmXCem8QCb3uB22HOgwbokc0QxSr00352XfRs5k=", "c9hPd5GDg/9Nyw5B+56KwQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Festival");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kMR5LuKXwNlBMGDWsIC7x6QG1qgY9dnFkt6udRhpE94=", "PQXj1QbX9NThmPdhDI8I5A==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lB0x+FmcyUqDNxRYfbd68cTU6mzxNJTwru5g1cAwL+M=", "PQXj1QbX9NThmPdhDI8I5A==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "byS1uBG9/+dJS7aP2t01oFGeKAg5714yZ6Ik9EscyT8=", "PQXj1QbX9NThmPdhDI8I5A==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5+Wt56G/fzvgQ2RwraevpRaQrqWhC7VcB8TXyE8g++A=", "PQXj1QbX9NThmPdhDI8I5A==" });
        }
    }
}
