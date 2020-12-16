using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class ChangeNullableAssignee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem",
                column: "AssigneeId",
                principalTable: "Assignee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem",
                column: "AssigneeId",
                principalTable: "Assignee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
