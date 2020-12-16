using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class IncludingSerializableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Week = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechDebt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptanceReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamBacklogDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InProgressDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwaitingCodeReviewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwaitingTestsDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestsCompletedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartImpedimentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndImpedimentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSheet_WorkItem_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheet_WorkItemId",
                table: "WorkSheet",
                column: "WorkItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSheet");
        }
    }
}
