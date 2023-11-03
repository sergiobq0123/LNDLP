using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class migra1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyTypeName",
                table: "CompanyType",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "KSNAPS0h1w5pQMLYOYP5UQeZBx2IGS/VqTyAlLKPvRU=", "A9Y/enfmrYNcRQR5PwGVEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "irS3wUpddJQfWmF2aXJ61TodohEVSjvIt+JkdiiiGJI=", "A9Y/enfmrYNcRQR5PwGVEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xN8RiT8+dxa8cw/qgUDR5AJWeoCSMsN4lrFHY0b7lnw=", "A9Y/enfmrYNcRQR5PwGVEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HkIJ2Mt697IpUP+AHbCMHOL7AWpcym+/NTS17PVou0A=", "A9Y/enfmrYNcRQR5PwGVEQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CompanyType",
                newName: "CompanyTypeName");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Ck5RjLR+P2rXfqwK83SlYLab9AzZDqqvt+/hdzsbsK4=", "B268lxTyNyI1wMDlX3+7hQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "croTc31hhIBdNT4MgGR6djPD6XN83CwtlsvxB0zntoM=", "B268lxTyNyI1wMDlX3+7hQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+Ds4m9+ot7bxjFqq5lJR3ZsngN2m9NEoGoYa5z/F9TU=", "B268lxTyNyI1wMDlX3+7hQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "XW3RrwLIuhzXI5n5pvTlyHSRnAwBU8JAIpRlHjdSc54=", "B268lxTyNyI1wMDlX3+7hQ==" });
        }
    }
}
