using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisTournament.Data.Migrations
{
    public partial class addPhotoFileNameToPlayer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "Players");
        }
    }
}
