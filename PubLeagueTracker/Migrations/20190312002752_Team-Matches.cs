using Microsoft.EntityFrameworkCore.Migrations;

namespace PubLeagueTracker.Migrations
{
    public partial class TeamMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDetail_Team_TeamId",
                table: "MatchDetail");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MatchDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDetail_Team_TeamId",
                table: "MatchDetail",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDetail_Team_TeamId",
                table: "MatchDetail");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "MatchDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDetail_Team_TeamId",
                table: "MatchDetail",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
