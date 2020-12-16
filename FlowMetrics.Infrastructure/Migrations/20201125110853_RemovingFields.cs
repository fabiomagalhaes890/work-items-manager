using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMetrics.Infrastructure.Migrations
{
    public partial class RemovingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Epic_EpicId",
                table: "WorkItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Week_WeekId",
                table: "WorkItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeekId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EpicId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Epic_EpicId",
                table: "WorkItem",
                column: "EpicId",
                principalTable: "Epic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Week_WeekId",
                table: "WorkItem",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Assignee_AssigneeId",
                table: "WorkItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Epic_EpicId",
                table: "WorkItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkItem_Week_WeekId",
                table: "WorkItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeekId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EpicId",
                table: "WorkItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Epic_EpicId",
                table: "WorkItem",
                column: "EpicId",
                principalTable: "Epic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItem_Week_WeekId",
                table: "WorkItem",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
