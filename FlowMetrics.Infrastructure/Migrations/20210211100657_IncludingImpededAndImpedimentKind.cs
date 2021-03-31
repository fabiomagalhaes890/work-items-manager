using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class IncludingImpededAndImpedimentKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImpedimentKind",
                table: "WorkItem",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpedimentKind",
                table: "WorkItem");
        }
    }
}
