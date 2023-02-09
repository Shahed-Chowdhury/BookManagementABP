using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagementABP.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                table: "App-Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_App-Books_PublisherId",
                table: "App-Books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_App-Books_App-Publishers_PublisherId",
                table: "App-Books",
                column: "PublisherId",
                principalTable: "App-Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App-Books_App-Publishers_PublisherId",
                table: "App-Books");

            migrationBuilder.DropIndex(
                name: "IX_App-Books_PublisherId",
                table: "App-Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "App-Books");
        }
    }
}
