using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseBroker.Migrations
{
    /// <inheritdoc />
    public partial class Alterskillstable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills");

            migrationBuilder.RenameColumn(
                name: "TeamMemberId",
                table: "skills",
                newName: "team_member_id");

            migrationBuilder.RenameIndex(
                name: "IX_skills_TeamMemberId",
                table: "skills",
                newName: "IX_skills_team_member_id");

            migrationBuilder.AddForeignKey(
                name: "FK_skills_team_members_team_member_id",
                table: "skills",
                column: "team_member_id",
                principalTable: "team_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skills_team_members_team_member_id",
                table: "skills");

            migrationBuilder.RenameColumn(
                name: "team_member_id",
                table: "skills",
                newName: "TeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_skills_team_member_id",
                table: "skills",
                newName: "IX_skills_TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills",
                column: "TeamMemberId",
                principalTable: "team_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
