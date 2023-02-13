using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementABP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedtableBookAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_App-BookAuthors",
                table: "App-BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_App-BookAuthors_AuthorId",
                table: "App-BookAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App-BookAuthors",
                table: "App-BookAuthors",
                columns: new[] { "AuthorId", "BookId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_App-BookAuthors",
                table: "App-BookAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App-BookAuthors",
                table: "App-BookAuthors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App-BookAuthors_AuthorId",
                table: "App-BookAuthors",
                column: "AuthorId");
        }
    }
}
