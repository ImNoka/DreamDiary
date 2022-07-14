using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    public partial class AddImagesToEntities4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "ImageProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_imageProfiles_ProfileGuid",
                table: "ImageProfiles",
                newName: "IX_ImageProfiles_ProfileGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageProfiles",
                table: "ImageProfiles",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProfiles_Profiles_ProfileGuid",
                table: "ImageProfiles",
                column: "ProfileGuid",
                principalTable: "Profiles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ImageProfiles_ImageProfileGuid",
                table: "Profiles",
                column: "ImageProfileGuid",
                principalTable: "ImageProfiles",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProfiles_Profiles_ProfileGuid",
                table: "ImageProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ImageProfiles_ImageProfileGuid",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageProfiles",
                table: "ImageProfiles");

            migrationBuilder.RenameTable(
                name: "ImageProfiles",
                newName: "imageProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProfiles_ProfileGuid",
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
    }
}
