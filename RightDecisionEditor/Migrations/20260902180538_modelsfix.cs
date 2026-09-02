using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightDecisionEditor.Migrations
{
    /// <inheritdoc />
    public partial class modelsfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoicesId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "ScenesId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_GameId",
                table: "Scenes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_SceneId",
                table: "Choices",
                column: "SceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_Games_GameId",
                table: "Scenes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_Games_GameId",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_GameId",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Choices_SceneId",
                table: "Choices");

            migrationBuilder.AddColumn<string>(
                name: "ChoicesId",
                table: "Scenes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScenesId",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
