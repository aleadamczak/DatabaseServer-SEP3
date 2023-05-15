using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class categoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Files",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Categories_CategoryName",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CategoryName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
