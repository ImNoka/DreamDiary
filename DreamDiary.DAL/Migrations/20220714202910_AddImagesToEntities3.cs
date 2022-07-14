using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class AddImagesToEntities3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProfile_Profiles_ProfileGuid",
                table: "ImageProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ImageProfile_ImageProfileGuid",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageProfile",
                table: "ImageProfile");

            migrationBuilder.RenameTable(
                name: "ImageProfile",
                newName: "imageProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProfile_ProfileGuid",
                table: "imageProfiles",
                newName: "IX_imageProfiles_ProfileGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imageProfiles",
                table: "imageProfiles",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_imageProfiles_Profiles_ProfileGuid",
                table: "imageProfiles",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_imageProfiles_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid",
                principalTable: "imageProfiles",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageProfiles_Profiles_ProfileGuid",
                table: "imageProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_imageProfiles_ImageProfileGuid",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_imageProfiles",
                table: "imageProfiles");

            migrationBuilder.RenameTable(
                name: "imageProfiles",
                newName: "ImageProfile");

            migrationBuilder.RenameIndex(
                name: "IX_imageProfiles_ProfileGuid",
                table: "ImageProfile",
                newName: "IX_ImageProfile_ProfileGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageProfile",
                table: "ImageProfile",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProfile_Profiles_ProfileGuid",
                table: "ImageProfile",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ImageProfile_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid",
                principalTable: "ImageProfile",
                principalColumn: "Guid");
        }
    }
}
