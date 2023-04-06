using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NJFencing.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fencers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    GradYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fencers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    Coach = table.Column<string>(type: "text", nullable: true),
                    Conference = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DualMeets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Conference = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Team1Id = table.Column<string>(type: "text", nullable: false),
                    Team1Score1 = table.Column<short>(type: "smallint", nullable: false),
                    Team1Score2 = table.Column<short>(type: "smallint", nullable: false),
                    Team1Score3 = table.Column<short>(type: "smallint", nullable: false),
                    Team1Score = table.Column<short>(type: "smallint", nullable: false),
                    Team2Id = table.Column<string>(type: "text", nullable: false),
                    Team2Score1 = table.Column<short>(type: "smallint", nullable: false),
                    Team2Score2 = table.Column<short>(type: "smallint", nullable: false),
                    Team2Score3 = table.Column<short>(type: "smallint", nullable: false),
                    Team2Score = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DualMeets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DualMeets_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DualMeets_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FencerRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FencerId = table.Column<string>(type: "text", nullable: false),
                    MeetId = table.Column<string>(type: "text", nullable: false),
                    Wins = table.Column<short>(type: "smallint", nullable: false),
                    Losses = table.Column<short>(type: "smallint", nullable: false),
                    Weapon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FencerRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FencerRecords_DualMeets_MeetId",
                        column: x => x.MeetId,
                        principalTable: "DualMeets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FencerRecords_Fencers_FencerId",
                        column: x => x.FencerId,
                        principalTable: "Fencers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DualMeets_Team1Id",
                table: "DualMeets",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_DualMeets_Team2Id",
                table: "DualMeets",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FencerRecords_FencerId",
                table: "FencerRecords",
                column: "FencerId");

            migrationBuilder.CreateIndex(
                name: "IX_FencerRecords_MeetId",
                table: "FencerRecords",
                column: "MeetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "FencerRecords");

            migrationBuilder.DropTable(
                name: "DualMeets");

            migrationBuilder.DropTable(
                name: "Fencers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
