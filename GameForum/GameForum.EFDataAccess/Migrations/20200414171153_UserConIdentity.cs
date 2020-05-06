using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameForum.EFDataAccess.Migrations
{
    public partial class UserConIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CreatorIDUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_CreatorIDUserId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Games_CreatorIDUserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CreatorIDUserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CreatorIDUserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatorIDUserId",
                table: "Comment");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDID",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDID",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatorIDID",
                table: "Games",
                column: "CreatorIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorIDID",
                table: "Comment",
                column: "CreatorIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_CreatorIDID",
                table: "Comment",
                column: "CreatorIDID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_CreatorIDID",
                table: "Games",
                column: "CreatorIDID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CreatorIDID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_CreatorIDID",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Games_CreatorIDID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CreatorIDID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorIDID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatorIDID",
                table: "Comment");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDUserId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDUserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatorIDUserId",
                table: "Games",
                column: "CreatorIDUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorIDUserId",
                table: "Comment",
                column: "CreatorIDUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_CreatorIDUserId",
                table: "Comment",
                column: "CreatorIDUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_CreatorIDUserId",
                table: "Games",
                column: "CreatorIDUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
