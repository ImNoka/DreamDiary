using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class AddImagesToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageProfileGuid",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageProfile",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProfile", x => x.Guid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ImageProfile_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid",
                principalTable: "ImageProfile",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ImageProfile_ImageProfileGuid",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "ImageProfile");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ImageProfileGuid",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ImageProfileGuid",
                table: "Profiles");
        }
    }
}
