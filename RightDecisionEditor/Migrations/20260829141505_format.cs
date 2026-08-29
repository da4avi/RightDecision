using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightDecisionEditor.Migrations
{
    /// <inheritdoc />
    public partial class format : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "choicesId",
                table: "Scenes",
                newName: "ChoicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoicesId",
                table: "Scenes",
                newName: "choicesId");
        }
    }
}
