using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro48 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g7xvkO0+id5be1Ah3TnFR3esYlPt1Xrgf6YoOacPO5w=", "7NB/yHGSwLpPMAQ62sfmyw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mhA1h1lzHUV+wSLXiXiJug2hQ2iqprb62IZUhADYYk4=", "7NB/yHGSwLpPMAQ62sfmyw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0SIa189UTQjFViOzEZJVWiZwsmu8ufUJmyHDQ9o1Uwg=", "7NB/yHGSwLpPMAQ62sfmyw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lfl+3z0JRIlpRjUoiOyoVWJ0YuZEufDpA6In1AfEUwY=", "7NB/yHGSwLpPMAQ62sfmyw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "707CVuAkcqmp1uSYLr4xdy6dYxBYk2+bwUzQY03b+bc=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6jLqxASrxXaNI9Rkh7N0Zd5sXZO7ddA/uWIm8HgC4eU=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "DDR5fl2b3TgVaoe+2vTuCbupHebL1F0APTAd1gOJ9Us=", "sZ9EqOv0jExYrOBkm2yTYQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lbYsok7jp/upvcwHzNpjAh/JiHHnY9J9zLVaGoeJpY8=", "sZ9EqOv0jExYrOBkm2yTYQ==" });
        }
    }
}
