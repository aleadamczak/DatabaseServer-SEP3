using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class privateFileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrivateFileId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrivateFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", nullable: false),
                    bytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    UploadedById = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateFiles_Users_UploadedById",
                        column: x => x.UploadedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrivateFileId",
                table: "Users",
                column: "PrivateFileId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFiles_UploadedById",
                table: "PrivateFiles",
                column: "UploadedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PrivateFiles_PrivateFileId",
                table: "Users",
                column: "PrivateFileId",
                principalTable: "PrivateFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PrivateFiles_PrivateFileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PrivateFiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_PrivateFileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrivateFileId",
                table: "Users");
        }
    }
}
