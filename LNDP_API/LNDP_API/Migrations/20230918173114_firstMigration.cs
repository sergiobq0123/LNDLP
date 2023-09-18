using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dj = table.Column<string>(type: "text", nullable: true),
                    RoadManager = table.Column<string>(type: "text", nullable: true),
                    SoundTechnician = table.Column<string>(type: "text", nullable: true),
                    LightingTechnician = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dosier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Photos = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosier", x => x.Id);
                });

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
                name: "SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Instagram = table.Column<string>(type: "text", nullable: true),
                    Youtube = table.Column<string>(type: "text", nullable: true),
                    Spotify = table.Column<string>(type: "text", nullable: true),
                    TikTok = table.Column<string>(type: "text", nullable: true),
                    Twitter = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetwork", x => x.Id);
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    UserRoleId = table.Column<int>(type: "integer", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    RecruitmentEmail = table.Column<string>(type: "text", nullable: true),
                    CommunicationEmail = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CrewId = table.Column<int>(type: "integer", nullable: true),
                    SocialNetworkId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artist_SocialNetwork_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetwork",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
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
                    { 1, new DateTime(2023, 9, 18, 17, 31, 14, 514, DateTimeKind.Utc).AddTicks(1722), "Festival", true },
                    { 2, new DateTime(2023, 9, 18, 17, 31, 14, 514, DateTimeKind.Utc).AddTicks(1723), "Concierto", true }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreationDate", "IsActive", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 18, 17, 31, 14, 514, DateTimeKind.Utc).AddTicks(1811), true, "Admin" },
                    { 2, new DateTime(2023, 9, 18, 17, 31, 14, 514, DateTimeKind.Utc).AddTicks(1812), true, "Crew" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CrewId",
                table: "Artist",
                column: "CrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_SocialNetworkId",
                table: "Artist",
                column: "SocialNetworkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_ArtistId",
                table: "Event",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeId",
                table: "Event",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dosier");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
