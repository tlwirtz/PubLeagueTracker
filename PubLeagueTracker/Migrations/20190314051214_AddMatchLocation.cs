using Microsoft.EntityFrameworkCore.Migrations;

namespace PubLeagueTracker.Migrations
{
    public partial class AddMatchLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Match",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Match");
        }
    }
}
