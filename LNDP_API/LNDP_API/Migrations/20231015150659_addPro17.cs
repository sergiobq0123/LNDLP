using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "R9jNx6eKbW/z9qnhiuSlLeGuoijRJe1GGdUjPhgy7Fg=", "LHuLcw52XzEIRZGpEZmFcA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "w8TPDwtVEd/+c8Ym1w/DE2NKCCLAGlgVt8v1UeRPmyI=", "LHuLcw52XzEIRZGpEZmFcA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Ddoah1LkYHBi3I5oqbBWb8zRS45rUokUPGESBpZOUN8=", "LHuLcw52XzEIRZGpEZmFcA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "t1q6Y/le8QBpodN9YRGPOE1YLH/ka6ixIpAGc1uxHcg=", "LHuLcw52XzEIRZGpEZmFcA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RMhavNDpQUqoDKr2+WsYBY1+7AoVp6u1nO7gToXUkvU=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4bR9jOOFV14pkozpiK2wo1US3SzSU3ew+bg2hiSqnZc=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "StBmBFv2L1HjEzAzk/fVW369rOaWvvyxbtS83po2ceY=", "BUgd71PLdir0eNCk3ODN5g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2ttcBUZUDfHdAYPBPQ6Ky/hrf9pkNEzXYg5phTVZzBA=", "BUgd71PLdir0eNCk3ODN5g==" });
        }
    }
}
