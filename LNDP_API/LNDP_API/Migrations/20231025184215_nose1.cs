using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class nose1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyTypeName",
                value: "Marca");

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyTypeName",
                value: "Sello");

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyTypeName",
                value: "Proyecto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "z4NRlgBKMjb/9jUdwyEGL53m2OLYQL4ZOr1K1+Cn0KA=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MXWZR5Pf98gKlZj1lIBppI0wK96VcmOET8iCgPDJ70o=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ZXtsQXLxppwrrDIiXYJNUN4nmLip9iIjR+Yhx5Q6dT0=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YMGicJvYg2F++FDcXuMmBPHuUWhOUIKa8uJmq13QTYg=", "lu7lO643JcUbgi5Bx4PyBw==" });

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyTypeName",
                value: "Brand");

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyTypeName",
                value: "Record");

            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyTypeName",
                value: "Project");
        }
    }
}
