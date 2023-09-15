﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNDP_API.Migrations
{
    /// <inheritdoc />
    public partial class fixrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 59, 43, 828, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 59, 43, 828, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 59, 43, 828, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 59, 43, 828, DateTimeKind.Utc).AddTicks(3912));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 51, 38, 271, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 51, 38, 271, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 51, 38, 271, DateTimeKind.Utc).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 15, 15, 51, 38, 271, DateTimeKind.Utc).AddTicks(7062));
        }
    }
}
