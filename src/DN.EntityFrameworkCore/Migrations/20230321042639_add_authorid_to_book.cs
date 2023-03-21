using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DN.Migrations
{
    /// <inheritdoc />
    public partial class addauthoridtobook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "BookStoreBooks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookStoreBooks_AuthorId",
                table: "BookStoreBooks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookStoreBooks_BookStoreAuthors_AuthorId",
                table: "BookStoreBooks",
                column: "AuthorId",
                principalTable: "BookStoreAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStoreBooks_BookStoreAuthors_AuthorId",
                table: "BookStoreBooks");

            migrationBuilder.DropIndex(
                name: "IX_BookStoreBooks_AuthorId",
                table: "BookStoreBooks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookStoreBooks");
        }
    }
}
