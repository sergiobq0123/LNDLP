using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class addPro41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "z9rCRw6TIzYz/HaqlrYRtIP7oaATyrBvzZJHd9pV9bw=", "F7a4c7kKFNFWMaFnHcjsyQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "zeNENACmg0lFlqkgysyGOWi3L26T/Y4u1rw4ToJYMlE=", "F7a4c7kKFNFWMaFnHcjsyQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mScgB4S5qDAInS5Sr9fabZczd/zj1njf4uVJTEWHzTg=", "F7a4c7kKFNFWMaFnHcjsyQ==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "5K8abdSrxlPc5l+Y0/0buG17rg8i1v9FfYGWzRsQlco=", "F7a4c7kKFNFWMaFnHcjsyQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "WtuE00i1+LvCWzX/yPq9bV0lnYIXU1jcbMPyQTFUrP8=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6TNzs5g/gAP8J/i4tDjBDDuKs4rBc/q1Ry+uyl2ZvEE=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "E/Yo/JIyHZh7Y660dGLgKEnlNPD4vWUy8E+cEW1SP9Q=", "rg7D8/hAcg3HBrGqCG6cmw==" });

            migrationBuilder.UpdateData(
                table: "Acces",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "w2m1E06gCqKc9/kgk3BeztNijRPUi9eTGzPnO/Tcrkc=", "rg7D8/hAcg3HBrGqCG6cmw==" });
        }
    }
}
