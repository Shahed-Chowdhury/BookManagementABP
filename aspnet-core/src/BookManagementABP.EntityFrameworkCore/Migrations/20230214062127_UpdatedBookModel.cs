using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementABP.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId1",
                table: "App-Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_App-Books_PublisherId1",
                table: "App-Books",
                column: "PublisherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_App-Books_App-Publishers_PublisherId1",
                table: "App-Books",
                column: "PublisherId1",
                principalTable: "App-Publishers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App-Books_App-Publishers_PublisherId1",
                table: "App-Books");

            migrationBuilder.DropIndex(
                name: "IX_App-Books_PublisherId1",
                table: "App-Books");

            migrationBuilder.DropColumn(
                name: "PublisherId1",
                table: "App-Books");
        }
    }
}
