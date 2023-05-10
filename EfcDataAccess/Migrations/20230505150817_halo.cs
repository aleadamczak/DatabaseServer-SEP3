using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class halo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "uploadedById",
                table: "Files",
                newName: "uploadedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Files_uploadedById",
                table: "Files",
                newName: "IX_Files_uploadedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_uploadedBy",
                table: "Files",
                column: "uploadedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_uploadedBy",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "uploadedBy",
                table: "Files",
                newName: "uploadedById");

            migrationBuilder.RenameIndex(
                name: "IX_Files_uploadedBy",
                table: "Files",
                newName: "IX_Files_uploadedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files",
                column: "uploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
