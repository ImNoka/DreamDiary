using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Dreams");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageGuid",
                table: "Goals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileGuid",
                table: "Goals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageGuid",
                table: "Dreams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ImageDream",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDream", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ImageGoal",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGoal", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "NoteGoal",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteGoal", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_NoteGoal_Goals_GoalGuid",
                        column: x => x.GoalGuid,
                        principalTable: "Goals",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ImageGuid",
                table: "Goals",
                column: "ImageGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProfileGuid",
                table: "Goals",
                column: "ProfileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_ImageGuid",
                table: "Dreams",
                column: "ImageGuid");

            migrationBuilder.CreateIndex(
                name: "IX_NoteGoal_GoalGuid",
                table: "NoteGoal",
                column: "GoalGuid");

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
                name: "FK_Goals_Profiles_ProfileGuid",
                table: "Goals",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_ImageDream_ImageGuid",
                table: "Dreams");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_ImageGoal_ImageGuid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Profiles_ProfileGuid",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "ImageDream");

            migrationBuilder.DropTable(
                name: "ImageGoal");

            migrationBuilder.DropTable(
                name: "NoteGoal");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ImageGuid",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ProfileGuid",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Dreams_ImageGuid",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "ImageGuid",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ProfileGuid",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ImageGuid",
                table: "Dreams");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Dreams",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
