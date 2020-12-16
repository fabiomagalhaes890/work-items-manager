using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class AddFieldsInEpic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsiderTTM",
                table: "Epic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpicId",
                table: "Epic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrioritized",
                table: "Epic",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Epic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsiderTTM",
                table: "Epic");

            migrationBuilder.DropColumn(
                name: "EpicId",
                table: "Epic");

            migrationBuilder.DropColumn(
                name: "IsPrioritized",
                table: "Epic");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Epic");
        }
    }
}
