using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RightDecisionEditor.Migrations
{
    /// <inheritdoc />
    public partial class firstscene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirstScene",
                table: "Scenes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstScene",
                table: "Scenes");
        }
    }
}
