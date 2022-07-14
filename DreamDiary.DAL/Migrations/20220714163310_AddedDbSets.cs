using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_ImageDream_ImageGuid",
                table: "Dreams");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_ImageGoal_ImageGuid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteGoal_Goals_GoalGuid",
                table: "NoteGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Profiles_ProfileGuid",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteGoal",
                table: "NoteGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageGoal",
                table: "ImageGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageDream",
                table: "ImageDream");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "ProfileNotes");

            migrationBuilder.RenameTable(
                name: "NoteGoal",
                newName: "GoalNotes");

            migrationBuilder.RenameTable(
                name: "ImageGoal",
                newName: "GoalImages");

            migrationBuilder.RenameTable(
                name: "ImageDream",
                newName: "DreamImages");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ProfileGuid",
                table: "ProfileNotes",
                newName: "IX_ProfileNotes_ProfileGuid");

            migrationBuilder.RenameIndex(
                name: "IX_NoteGoal_GoalGuid",
                table: "GoalNotes",
                newName: "IX_GoalNotes_GoalGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileNotes",
                table: "ProfileNotes",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalNotes",
                table: "GoalNotes",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GoalImages",
                table: "GoalImages",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DreamImages",
                table: "DreamImages",
                column: "Guid");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "TaskNotes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskNotes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TaskNotes_Tasks_TaskGuid",
                        column: x => x.TaskGuid,
                        principalTable: "Tasks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_TaskGuid",
                table: "TaskNotes",
                column: "TaskGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_DreamImages_ImageGuid",
                table: "Dreams",
                column: "ImageGuid",
                principalTable: "DreamImages",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalNotes_Goals_GoalGuid",
                table: "GoalNotes",
                column: "GoalGuid",
                principalTable: "Goals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_GoalImages_ImageGuid",
                table: "Goals",
                column: "ImageGuid",
                principalTable: "GoalImages",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileNotes_Profiles_ProfileGuid",
                table: "ProfileNotes",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_DreamImages_ImageGuid",
                table: "Dreams");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalNotes_Goals_GoalGuid",
                table: "GoalNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_GoalImages_ImageGuid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileNotes_Profiles_ProfileGuid",
                table: "ProfileNotes");

            migrationBuilder.DropTable(
                name: "TaskNotes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileNotes",
                table: "ProfileNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalNotes",
                table: "GoalNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GoalImages",
                table: "GoalImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DreamImages",
                table: "DreamImages");

            migrationBuilder.RenameTable(
                name: "ProfileNotes",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "GoalNotes",
                newName: "NoteGoal");

            migrationBuilder.RenameTable(
                name: "GoalImages",
                newName: "ImageGoal");

            migrationBuilder.RenameTable(
                name: "DreamImages",
                newName: "ImageDream");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileNotes_ProfileGuid",
                table: "Notes",
                newName: "IX_Notes_ProfileGuid");

            migrationBuilder.RenameIndex(
                name: "IX_GoalNotes_GoalGuid",
                table: "NoteGoal",
                newName: "IX_NoteGoal_GoalGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteGoal",
                table: "NoteGoal",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageGoal",
                table: "ImageGoal",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageDream",
                table: "ImageDream",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_ImageDream_ImageGuid",
                table: "Dreams",
                column: "ImageGuid",
                principalTable: "ImageDream",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_ImageGoal_ImageGuid",
                table: "Goals",
                column: "ImageGuid",
                principalTable: "ImageGoal",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteGoal_Goals_GoalGuid",
                table: "NoteGoal",
                column: "GoalGuid",
                principalTable: "Goals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Profiles_ProfileGuid",
                table: "Notes",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
