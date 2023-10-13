using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyTypeName",
                value: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CompanyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CompanyTypeName",
                value: "Projectos");
        }
    }
}
