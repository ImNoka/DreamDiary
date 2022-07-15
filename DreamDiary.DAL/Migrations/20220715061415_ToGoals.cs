using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class ToGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GoalGuid",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GoalGuid",
                table: "Tasks",
                column: "GoalGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Goals_GoalGuid",
                table: "Tasks",
                column: "GoalGuid",
                principalTable: "Goals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Goals_GoalGuid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_GoalGuid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "GoalGuid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Goals");
        }
    }
}
