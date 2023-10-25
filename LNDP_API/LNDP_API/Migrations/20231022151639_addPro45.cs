using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FED8LitOQKXcymnIKgciU6rbrHa552Hw3ctncwNJxto=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "uH3jXn3CDUkb4r0a6dblbMwL7SJYi0W8eU9L/g37l9U=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SlqjeZ0OHB3oXDdDBm/OaRWsvo2BdRo4/5LZYtCscFM=", "RY1YlPXdupt9oHVm0cTxEQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "04TWdywReOVIalgJAnBzLB7t8nYCPiCSxz92PcxZ+rg=", "RY1YlPXdupt9oHVm0cTxEQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+5OxEVv4jLK12nC/24Cb7eJWAkTOfuu7pcebALH9N70=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YVL63FfQI4ipcs5ZftIrSdVkTDzKmrdGac12EO2tMds=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5DH/65koPZ2Rrcm6EjXvsQbygFNDRedF/6oh9b7Muxw=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lBxzjFhhr5age0taC02615rLazvpHmuXNABVdSJrG+U=", "/gJc4wTsF1gM+WY0Zkd0XQ==" });
        }
    }
}
