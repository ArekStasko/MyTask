using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTask.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Raports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Raports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");
        }
    }
}
