using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinder.DAL.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Users",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BestEmotion",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BestEmotion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Users",
                newName: "Sex");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
