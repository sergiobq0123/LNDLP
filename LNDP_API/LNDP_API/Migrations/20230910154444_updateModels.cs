using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_IdCrewId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_IdUserId",
                table: "Artist");

            migrationBuilder.DropTable(
                name: "ArtistFestival");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Festival");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "Artist",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdCrewId",
                table: "Artist",
                newName: "SocialNetworkId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_IdUserId",
                table: "Artist",
                newName: "IX_Artist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_IdCrewId",
                table: "Artist",
                newName: "IX_Artist_SocialNetworkId");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "User",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Artist",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    UrlLocation = table.Column<string>(type: "text", nullable: true),
                    Tickets = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventTypeId = table.Column<int>(type: "integer", nullable: true),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { "Id", "CreationDate", "EventName", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4846), "Festival", true },
                    { 2, new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4848), "Concierto", true }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreationDate", "IsActive", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4945), true, "Admin" },
                    { 2, new DateTime(2023, 9, 10, 15, 44, 43, 837, DateTimeKind.Utc).AddTicks(4946), true, "Crew" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId",
                table: "Artist",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ArtistId",
                table: "Event",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeId",
                table: "Event",
                column: "EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_SocialNetwork_SocialNetworkId",
                table: "Artist",
                column: "SocialNetworkId",
                principalTable: "SocialNetwork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_UserRoleId",
                table: "User",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Crew_CrewId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_SocialNetwork_SocialNetworkId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_UserRoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_User_UserRoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Artist_CrewId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Artist");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Artist",
                newName: "IdUserId");

            migrationBuilder.RenameColumn(
                name: "SocialNetworkId",
                table: "Artist",
                newName: "IdCrewId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                newName: "IX_Artist_IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist",
                newName: "IX_Artist_IdCrewId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Tickets = table.Column<string>(type: "text", nullable: true),
                    UrlLocation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Festival",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Tickets = table.Column<string>(type: "text", nullable: true),
                    UrlLocation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistFestival",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "integer", nullable: false),
                    FestivalsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFestival", x => new { x.ArtistsId, x.FestivalsId });
                    table.ForeignKey(
                        name: "FK_ArtistFestival_Artist_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFestival_Festival_FestivalsId",
                        column: x => x.FestivalsId,
                        principalTable: "Festival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestival_FestivalsId",
                table: "ArtistFestival",
                column: "FestivalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_ArtistId",
                table: "Concert",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Crew_IdCrewId",
                table: "Artist",
                column: "IdCrewId",
                principalTable: "Crew",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_IdUserId",
                table: "Artist",
                column: "IdUserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
