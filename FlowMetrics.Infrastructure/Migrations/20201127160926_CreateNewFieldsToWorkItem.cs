using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class CreateNewFieldsToWorkItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestsCompletedDate",
                table: "WorkSheet",
                newName: "ToDoDate");

            migrationBuilder.RenameColumn(
                name: "TeamBacklogDate",
                table: "WorkSheet",
                newName: "TestingInAcceptanceDate");

            migrationBuilder.RenameColumn(
                name: "IncludedDate",
                table: "WorkSheet",
                newName: "DoneDate");

            migrationBuilder.RenameColumn(
                name: "TestsCompletedDate",
                table: "WorkItem",
                newName: "ToDoDate");

            migrationBuilder.RenameColumn(
                name: "TeamBacklogDate",
                table: "WorkItem",
                newName: "TestingInAcceptanceDate");

            migrationBuilder.RenameColumn(
                name: "IncludedDate",
                table: "WorkItem",
                newName: "BacklogDate");

            migrationBuilder.AddColumn<string>(
                name: "AwaitingAcceptanceTestsDate",
                table: "WorkSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwaitingProductionDate",
                table: "WorkSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BacklogDate",
                table: "WorkSheet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AwaitingAcceptanceTestsDate",
                table: "WorkItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AwaitingProductionDate",
                table: "WorkItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneDate",
                table: "WorkItem",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwaitingAcceptanceTestsDate",
                table: "WorkSheet");

            migrationBuilder.DropColumn(
                name: "AwaitingProductionDate",
                table: "WorkSheet");

            migrationBuilder.DropColumn(
                name: "BacklogDate",
                table: "WorkSheet");

            migrationBuilder.DropColumn(
                name: "AwaitingAcceptanceTestsDate",
                table: "WorkItem");

            migrationBuilder.DropColumn(
                name: "AwaitingProductionDate",
                table: "WorkItem");

            migrationBuilder.DropColumn(
                name: "DoneDate",
                table: "WorkItem");

            migrationBuilder.RenameColumn(
                name: "ToDoDate",
                table: "WorkSheet",
                newName: "TestsCompletedDate");

            migrationBuilder.RenameColumn(
                name: "TestingInAcceptanceDate",
                table: "WorkSheet",
                newName: "TeamBacklogDate");

            migrationBuilder.RenameColumn(
                name: "DoneDate",
                table: "WorkSheet",
                newName: "IncludedDate");

            migrationBuilder.RenameColumn(
                name: "ToDoDate",
                table: "WorkItem",
                newName: "TestsCompletedDate");

            migrationBuilder.RenameColumn(
                name: "TestingInAcceptanceDate",
                table: "WorkItem",
                newName: "TeamBacklogDate");

            migrationBuilder.RenameColumn(
                name: "BacklogDate",
                table: "WorkItem",
                newName: "IncludedDate");
        }
    }
}
