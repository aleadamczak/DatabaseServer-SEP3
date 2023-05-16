using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class olafix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            

            migrationBuilder.AlterColumn<int>(
                name: "UploadedById",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Files",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CategoryName",
                table: "Files",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Categories_CategoryName",
                table: "Files",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UploadedById",
                table: "Files",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Categories_CategoryName",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UploadedById",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CategoryName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UploadedById",
                table: "Files",
                newName: "uploadedById");

            migrationBuilder.RenameIndex(
                name: "IX_Files_UploadedById",
                table: "Files",
                newName: "IX_Files_uploadedById");

            migrationBuilder.AlterColumn<int>(
                name: "uploadedById",
                table: "Files",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_uploadedById",
                table: "Files",
                column: "uploadedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
