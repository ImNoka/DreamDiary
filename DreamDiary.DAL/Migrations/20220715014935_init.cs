using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "DreamImages",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DreamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamImages", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Dreams",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageDreamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreams", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Dreams_DreamImages_ImageDreamGuid",
                        column: x => x.ImageDreamGuid,
                        principalTable: "DreamImages",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "GoalImages",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalImages", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "GoalNotes",
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
                    table.PrimaryKey("PK_GoalNotes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageDreamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Goals_GoalImages_ImageDreamGuid",
                        column: x => x.ImageDreamGuid,
                        principalTable: "GoalImages",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ImageProfiles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProfiles", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageProfileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Profiles_ImageProfiles_ImageProfileGuid",
                        column: x => x.ImageProfileGuid,
                        principalTable: "ImageProfiles",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileNotes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileNotes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ProfileNotes_Profiles_ProfileGuid",
                        column: x => x.ProfileGuid,
                        principalTable: "Profiles",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DreamImages_DreamGuid",
                table: "DreamImages",
                column: "DreamGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_ImageDreamGuid",
                table: "Dreams",
                column: "ImageDreamGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_ProfileGuid",
                table: "Dreams",
                column: "ProfileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GoalImages_GoalGuid",
                table: "GoalImages",
                column: "GoalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GoalNotes_GoalGuid",
                table: "GoalNotes",
                column: "GoalGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ImageDreamGuid",
                table: "Goals",
                column: "ImageDreamGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProfileGuid",
                table: "Goals",
                column: "ProfileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProfiles_ProfileGuid",
                table: "ImageProfiles",
                column: "ProfileGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileNotes_ProfileGuid",
                table: "ProfileNotes",
                column: "ProfileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_TaskGuid",
                table: "TaskNotes",
                column: "TaskGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_DreamImages_Dreams_DreamGuid",
                table: "DreamImages",
                column: "DreamGuid",
                principalTable: "Dreams",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_Profiles_ProfileGuid",
                table: "Dreams",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalImages_Goals_GoalGuid",
                table: "GoalImages",
                column: "GoalGuid",
                principalTable: "Goals",
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
                name: "FK_Goals_Profiles_ProfileGuid",
                table: "Goals",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProfiles_Profiles_ProfileGuid",
                table: "ImageProfiles",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DreamImages_Dreams_DreamGuid",
                table: "DreamImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Profiles_ProfileGuid",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProfiles_Profiles_ProfileGuid",
                table: "ImageProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalImages_Goals_GoalGuid",
                table: "GoalImages");

            migrationBuilder.DropTable(
                name: "GoalNotes");

            migrationBuilder.DropTable(
                name: "ProfileNotes");

            migrationBuilder.DropTable(
                name: "TaskNotes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Dreams");

            migrationBuilder.DropTable(
                name: "DreamImages");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ImageProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "GoalImages");
        }
    }
}
