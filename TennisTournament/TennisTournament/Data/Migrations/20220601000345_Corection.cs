using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisTournament.Data.Migrations
{
    public partial class Corection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaguesPlayers",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaguesPlayers", x => new { x.LeagueId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_LeaguesPlayers_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaguesPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaguesPlayers_PlayerId",
                table: "LeaguesPlayers",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaguesPlayers");
        }
    }
}
