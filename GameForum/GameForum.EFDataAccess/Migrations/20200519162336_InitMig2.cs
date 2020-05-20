using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameForum.EFDataAccess.Migrations
{
    public partial class InitMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CreatorIDID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Games_GameID",
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

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Comment",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_GameID",
                table: "Comment",
                newName: "IX_Comment_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameID",
                table: "Games",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreatorID",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorID",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Games_GameId",
                table: "Comment",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Games_GameId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Comment",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_GameId",
                table: "Comment",
                newName: "IX_Comment_GameID");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "GameID",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDID",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GameID",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorIDID",
                table: "Comment",
                type: "uniqueidentifier",
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
                name: "FK_Comment_Games_GameID",
                table: "Comment",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_CreatorIDID",
                table: "Games",
                column: "CreatorIDID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
