using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class AddImagesToEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileGuid",
                table: "ImageProfile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ImageProfile_ProfileGuid",
                table: "ImageProfile",
                column: "ProfileGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProfile_Profiles_ProfileGuid",
                table: "ImageProfile",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProfile_Profiles_ProfileGuid",
                table: "ImageProfile");

            migrationBuilder.DropIndex(
                name: "IX_ImageProfile_ProfileGuid",
                table: "ImageProfile");

            migrationBuilder.DropColumn(
                name: "ProfileGuid",
                table: "ImageProfile");
        }
    }
}
