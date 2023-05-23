using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class privateFileConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PrivateFiles_PrivateFileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PrivateFileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrivateFileId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "PrivateFileUser",
                columns: table => new
                {
                    SharedWithId = table.Column<int>(type: "INTEGER", nullable: false),
                    SharedWithMeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateFileUser", x => new { x.SharedWithId, x.SharedWithMeId });
                    table.ForeignKey(
                        name: "FK_PrivateFileUser_PrivateFiles_SharedWithMeId",
                        column: x => x.SharedWithMeId,
                        principalTable: "PrivateFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateFileUser_Users_SharedWithId",
                        column: x => x.SharedWithId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFileUser_SharedWithMeId",
                table: "PrivateFileUser",
                column: "SharedWithMeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateFileUser");

            migrationBuilder.AddColumn<int>(
                name: "PrivateFileId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PrivateFileId",
                table: "Users",
                column: "PrivateFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PrivateFiles_PrivateFileId",
                table: "Users",
                column: "PrivateFileId",
                principalTable: "PrivateFiles",
                principalColumn: "Id");
        }
    }
}
