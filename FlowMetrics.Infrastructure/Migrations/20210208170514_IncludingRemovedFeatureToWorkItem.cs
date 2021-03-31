using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class IncludingRemovedFeatureToWorkItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "WorkItem",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "WorkItem");
        }
    }
}
