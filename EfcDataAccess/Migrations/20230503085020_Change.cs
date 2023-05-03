using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "bytestream",
                table: "Files",
                newName: "bytes");

            migrationBuilder.AlterColumn<int>(
                name: "uploadedById",
                table: "Files",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files",
                column: "uploadedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "bytes",
                table: "Files",
                newName: "bytestream");

            migrationBuilder.AlterColumn<int>(
                name: "uploadedById",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
