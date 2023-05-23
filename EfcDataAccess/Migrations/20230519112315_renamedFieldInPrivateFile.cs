using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class renamedFieldInPrivateFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateFileUser_Users_SharedWithId",
                table: "PrivateFileUser");

            migrationBuilder.RenameColumn(
                name: "SharedWithId",
                table: "PrivateFileUser",
                newName: "HaveAccessId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateFileUser_Users_HaveAccessId",
                table: "PrivateFileUser",
                column: "HaveAccessId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateFileUser_Users_HaveAccessId",
                table: "PrivateFileUser");

            migrationBuilder.RenameColumn(
                name: "HaveAccessId",
                table: "PrivateFileUser",
                newName: "SharedWithId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateFileUser_Users_SharedWithId",
                table: "PrivateFileUser",
                column: "SharedWithId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
