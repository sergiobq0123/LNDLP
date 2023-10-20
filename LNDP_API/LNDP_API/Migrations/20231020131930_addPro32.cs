using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "t+fE6GpcKkgjzfT69V6sw8KzQGMjB17aJ/w/ttIAvTw=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "WspuyZi4mECedcUIjhC/gm33Thw4BZT0pz3BXP6SWHo=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "B1XWlyZOEY99AABghZ9bSMtCv/yUKR2aXkBIM58ZzAc=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SnutaNMde71s8qmOtSxqCOYQ4Ghq+X3LHrwhu9xyRXY=", "GLuO0mwGJ2Sfo52Kz4JNyA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
