﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NadekoBot.Migrations
{
    public partial class removepatreonrewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RewardedUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RewardedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AmountRewardedThisMonth = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    LastReward = table.Column<DateTime>(nullable: false),
                    PatreonUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardedUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RewardedUsers_UserId",
                table: "RewardedUsers",
                column: "UserId",
                unique: true);
        }
    }
}
