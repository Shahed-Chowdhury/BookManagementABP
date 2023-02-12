using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementABP.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTableBookAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App-BookAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App-BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App-BookAuthors_App-Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "App-Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App-BookAuthors_App-Books_BookId",
                        column: x => x.BookId,
                        principalTable: "App-Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App-BookAuthors_AuthorId",
                table: "App-BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_App-BookAuthors_BookId",
                table: "App-BookAuthors",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App-BookAuthors");
        }
    }
}
