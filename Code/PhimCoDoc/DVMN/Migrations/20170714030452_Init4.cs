using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DVMN.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AuthorID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Tag",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "SSinglePuzzle",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "SinglePuzzleDetails",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "MultiPuzzle",
                newName: "MemberID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "SSinglePuzzle",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "SSinglePuzzle",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "SSinglePuzzle",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "SinglePuzzleDetails",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "SinglePuzzleDetails",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "SinglePuzzleDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "MultiPuzzle",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "MultiPuzzle",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "MultiPuzzle",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approved",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDT",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Image",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MemberID",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDT",
                table: "Image",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "MemberID",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_Tag_MemberID",
                table: "Tag",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SSinglePuzzle_MemberID",
                table: "SSinglePuzzle",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SinglePuzzleDetails_MemberID",
                table: "SinglePuzzleDetails",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MultiPuzzle_MemberID",
                table: "MultiPuzzle",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MemberID",
                table: "Image",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MemberID",
                table: "Comment",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_MemberID",
                table: "Comment",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_MemberID",
                table: "Image",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MultiPuzzle_AspNetUsers_MemberID",
                table: "MultiPuzzle",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SinglePuzzleDetails_AspNetUsers_MemberID",
                table: "SinglePuzzleDetails",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SSinglePuzzle_AspNetUsers_MemberID",
                table: "SSinglePuzzle",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_MemberID",
                table: "Tag",
                column: "MemberID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_MemberID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_MemberID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_MultiPuzzle_AspNetUsers_MemberID",
                table: "MultiPuzzle");

            migrationBuilder.DropForeignKey(
                name: "FK_SinglePuzzleDetails_AspNetUsers_MemberID",
                table: "SinglePuzzleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SSinglePuzzle_AspNetUsers_MemberID",
                table: "SSinglePuzzle");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_MemberID",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_MemberID",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_SSinglePuzzle_MemberID",
                table: "SSinglePuzzle");

            migrationBuilder.DropIndex(
                name: "IX_SinglePuzzleDetails_MemberID",
                table: "SinglePuzzleDetails");

            migrationBuilder.DropIndex(
                name: "IX_MultiPuzzle_MemberID",
                table: "MultiPuzzle");

            migrationBuilder.DropIndex(
                name: "IX_Image_MemberID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Comment_MemberID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "CreateDT",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdateDT",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Tag",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "SSinglePuzzle",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "SinglePuzzleDetails",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "MultiPuzzle",
                newName: "AuthorID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "Tag",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "Tag",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorID",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "SSinglePuzzle",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "SSinglePuzzle",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorID",
                table: "SSinglePuzzle",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "SinglePuzzleDetails",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "SinglePuzzleDetails",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorID",
                table: "SinglePuzzleDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "MultiPuzzle",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "MultiPuzzle",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorID",
                table: "MultiPuzzle",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDT",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorID",
                table: "Comment",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorID",
                table: "Comment",
                column: "AuthorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
