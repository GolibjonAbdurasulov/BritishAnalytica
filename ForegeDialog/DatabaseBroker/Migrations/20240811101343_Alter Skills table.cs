using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseBroker.Migrations
{
    /// <inheritdoc />
    public partial class AlterSkillstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills");

            migrationBuilder.AlterColumn<long>(
                name: "TeamMemberId",
                table: "skills",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills",
                column: "TeamMemberId",
                principalTable: "team_members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills");

            migrationBuilder.AlterColumn<long>(
                name: "TeamMemberId",
                table: "skills",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_skills_team_members_TeamMemberId",
                table: "skills",
                column: "TeamMemberId",
                principalTable: "team_members",
                principalColumn: "id");
        }
    }
}
